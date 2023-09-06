using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
	public class AuthenticationService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserProfileRepository _profileRepo;

		public AuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, UserProfileRepository profileRepo)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_profileRepo = profileRepo;
		}

		public async Task<bool> RegisterAsync(RegisterModel model)
		{
			IdentityUser user = model;
			var isFirstUser = !_userManager.Users.Any();
			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				var role = isFirstUser ? "Admin" : "Produktansvarig";
				if (!await _roleManager.RoleExistsAsync(role))
					await _roleManager.CreateAsync(new IdentityRole(role));

				await _userManager.AddToRoleAsync(user, role);

				var createdUser = await _userManager.FindByEmailAsync(model.Email!);

				UserProfileEntity profile = model;
				profile.UserId = createdUser!.Id;
				await _profileRepo.AddAsync(profile);

				return true;
			}

			return false;
		}


		public async Task<string> LoginAsync(LoginModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user != null)
			{
				var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
				if (passwordCheck.Succeeded)
				{
					var role = await _userManager.GetRolesAsync(user);
					var claims = new ClaimsIdentity(new Claim[]
						{
					new Claim("id", user.Id),
					new Claim(ClaimTypes.Role, role.First()),
					new Claim(ClaimTypes.Name, user.Email!)
						});

					return TokenGenerator.Generate(claims, DateTime.Now.AddDays(1));
				}
			}

			return string.Empty;
		}
	}
}
