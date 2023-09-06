using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly CommentRepository _commentRepository;

		public CommentsController(CommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}

		[Route("add")]
		[HttpPost]
		public async Task<IActionResult> AddCommentAsync(Comment comment)
		{
			return Ok(await _commentRepository.AddAsync(comment));
		}

		[Route("all")]
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			return Ok(await _commentRepository.GetAllAsync());
		}
	}
}
