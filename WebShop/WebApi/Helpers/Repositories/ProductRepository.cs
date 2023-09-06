using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
	public class ProductRepository : Repository<ProductEntity>
	{
		private readonly DataContext _context;
		public ProductRepository(DataContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
		{
			try
			{
				var result = await _context.Products.Include("Category").ToListAsync();
				return result;
			}
			catch (Exception ex) { Debug.WriteLine(ex.Message); }
			return null!;
		}


		public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
		{
			try
			{
				var result = await _context.Products.Include("Category").Where(expression).ToListAsync();

				return result;
			}
			catch (Exception ex) { Debug.WriteLine(ex.Message); }
			return null!;
		}


		public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
		{
			try
			{
				var result = await _context.Products.Include("Category").FirstOrDefaultAsync(expression);
				if (result != null)
					return result;
			}
			catch (Exception ex) { Debug.WriteLine(ex.Message); }
			return null!;
		}

	}
}
