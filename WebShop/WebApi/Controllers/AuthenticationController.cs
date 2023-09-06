using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly AuthenticationService _authService;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AuthenticationController(AuthenticationService authService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_authService = authService;
			_userManager = userManager;
			_signInManager = signInManager;
		}


		[HttpPost("Register")]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				if (await _authService.RegisterAsync(model))
					return Created("", null!);
			}

			return BadRequest();
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var token = await _authService.LoginAsync(model);
					if (!string.IsNullOrEmpty(token))
						return Ok(token);

					ModelState.AddModelError("", "Incorrect email or password");
					return Unauthorized(model);
				}

				return BadRequest(model);
			}
			catch { return Problem(); }
		}
	}
}
