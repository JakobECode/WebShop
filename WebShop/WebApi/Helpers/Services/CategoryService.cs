using WebApi.Contexts;

namespace WebApi.Helpers.Services
{
	public class CategoryService
	{
		private readonly DataContext _context;

		public CategoryService(DataContext context)
		{
			_context = context;
		}
	}
}
