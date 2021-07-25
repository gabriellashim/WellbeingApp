using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Quokka_App.Model;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Quokka_App
{
	public class AdditionalUserClaimsPrincipalFactory
		  : UserClaimsPrincipalFactory<WebAppUser, IdentityRole>
	{
		public AdditionalUserClaimsPrincipalFactory(
			UserManager<WebAppUser> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<IdentityOptions> optionsAccessor)
			: base(userManager, roleManager, optionsAccessor)
		{ }

		//public async override Task<ClaimsPrincipal> CreateAsync(WebAppUser user)
		//{
		//	var principal = await base.CreateAsync(user);
		//	var identity = (ClaimsIdentity)principal.Identity;

		//	var claims = new List<Claim>();
		//	if (user.IsAdmin)
		//	{
		//		claims.Add(new Claim(JwtClaimTypes.Role, "admin"));
		//	}
		//	else
		//	{
		//		claims.Add(new Claim(JwtClaimTypes.Role, "user"));
		//	}

		//	identity.AddClaims(claims);
		//	return principal;
		//}
	}
}