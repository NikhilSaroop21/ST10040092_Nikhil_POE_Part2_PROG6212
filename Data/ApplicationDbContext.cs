using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Provides Identity support with EF Core
using Microsoft.EntityFrameworkCore; // For Entity Framework Core functionality
using ST10040092_Nikhil_POE_Part2_PROG6212.Models; // References the application's data models

namespace ST10040092_Nikhil_POE_Part2_PROG6212.Data
{
	// Inherit from IdentityDbContext to integrate ASP.NET Identity with Entity Framework Core
	public class ApplicationDbContext : IdentityDbContext
	{
		// Constructor that takes DbContextOptions to configure the database context
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) // Calls the base class constructor with the given options
		{
		}

		// DbSet for User entities, representing the Users table in the database
		public DbSet<User> User { get; set; }

		// DbSet for Claim entities, representing the Claims table in the database
		public DbSet<Claim> Claims { get; set; }
	}
}
