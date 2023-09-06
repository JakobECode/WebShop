using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CategoryRepository _categoryRepo;

		public CategoriesController(CategoryRepository categoryRepo)
		{
			_categoryRepo = categoryRepo;
		}

		[Route("all")]
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			return Ok(await _categoryRepo.GetAllAsync());
		}
	}
}
