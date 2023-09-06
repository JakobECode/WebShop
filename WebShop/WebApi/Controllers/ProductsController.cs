using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ProductRepository _productRepo;
		private readonly ProductService _productService;

		public ProductsController(ProductRepository productRepo, ProductService productService)
		{
			_productRepo = productRepo;
			_productService = productService;
		}

		[Route("all")]
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			return Ok(await _productService.GetAllAsync());
		}

		[Route("id")]
		[HttpGet]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			return Ok(await _productService.GetAsync(x => x.Id == id));
		}

		[Route("tag")]
		[HttpGet]
		public async Task<IActionResult> GetByTagAsync(string tag)
		{
			return Ok(await _productService.GetAllAsync(x => x.Tag == tag));
		}

		[Route("add")]
		[HttpPost]
		public async Task<IActionResult> AddProductAsync(Product product)
		{
			return Ok(await _productService.CreateAsync(product));
		}
	}
}
