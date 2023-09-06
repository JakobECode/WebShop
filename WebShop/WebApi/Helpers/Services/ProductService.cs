using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
	public class ProductService
	{
		private readonly DataContext _context;
		private readonly ProductRepository _productRepo;
		private readonly CategoryRepository _categoryRepo;

		public ProductService(DataContext context, ProductRepository productRepo, CategoryRepository categoryRepo)
		{
			_context = context;
			_productRepo = productRepo;
			_categoryRepo = categoryRepo;
		}


		public async Task<ProductEntity> CreateAsync(Product product)
		{
			ProductEntity entity = product;
			return await _productRepo.AddAsync(entity);
		}


		public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
		{
			try
			{
				var result = await _productRepo.GetAllAsync(expression);
				var products = new List<Product>();
				if (result != null)
				{
					foreach (var entity in result)
					{
						Product product = entity;
						products.Add(product);
					}
				}

				return products;
			}
			catch (Exception ex) { Debug.WriteLine(ex.Message); }
			return null!;
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			try
			{
				var result = await _productRepo.GetAllAsync();
				var products = new List<Product>();
				if(result != null)
				{
                    foreach (var entity in result)
                    {
                        Product product = entity;
                        products.Add(product);
                    }
                }

				return products;
			}
			catch (Exception ex) { Debug.WriteLine(ex.Message); }
			return null!;
		}

		public async Task<Product> GetAsync(Expression<Func<ProductEntity, bool>> expression)
		{
			var entity = await _productRepo.GetAsync(expression);
			Product product = entity;
			return product;
		}
	}
}
