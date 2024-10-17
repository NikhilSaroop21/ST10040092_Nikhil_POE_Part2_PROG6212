using Microsoft.AspNetCore.Identity;

namespace ST10040092_Nikhil_POE_Part2_PROG6212
{

	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
}