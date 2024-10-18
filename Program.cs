using Microsoft.AspNetCore.Identity; // For Identity management (users and roles)
using Microsoft.EntityFrameworkCore; // For database operations
using Microsoft.Extensions.Logging; // For logging capabilities
using ST10040092_Nikhil_POE_Part2_PROG6212.Data; // Custom application data namespace

namespace ST10040092_Nikhil_POE_Part2_PROG6212
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args); // Initialize the builder for the web app

			// Configure database connection string
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
				?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			// Add ApplicationDbContext to the service container with SQL Server configuration
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));

			// Enable detailed exception pages for developers
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			// Configure Identity with roles and password policies
			builder.Services.AddDefaultIdentity<IdentityUser>(options =>
			{
				options.Password.RequireDigit = true; // Require at least one digit
				options.Password.RequireLowercase = true; // Require lowercase characters
				options.Password.RequiredLength = 6; // Minimum password length of 6 characters
			})
			.AddRoles<IdentityRole>() // Enable role management
			.AddEntityFrameworkStores<ApplicationDbContext>() // Use EF Core with Identity
			.AddDefaultTokenProviders(); // Add token providers for authentication features

			// Add support for MVC controllers and views
			builder.Services.AddControllersWithViews();

			// Configure logging to write logs to the console
			builder.Logging.ClearProviders(); // Clear existing logging providers
			builder.Logging.AddConsole(); // Add console logging

			var app = builder.Build(); // Build the application

			// Configure the HTTP request pipeline
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage(); // Enable detailed error pages in development
				app.UseMigrationsEndPoint(); // Use migration endpoint for database updates
			}
			else
			{
				app.UseExceptionHandler("/Home/Error"); // Handle errors in production with a custom error page
				app.UseHsts(); // Enforce HTTPS in production
			}

			app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
			app.UseStaticFiles(); // Enable serving of static files (like CSS, JS, images)

			app.UseRouting(); // Enable routing middleware

			// Add authentication and authorization middleware
			app.UseAuthentication(); // Enable authentication
			app.UseAuthorization(); // Enable role-based authorization

			// Configure default route for MVC controllers
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			// Map Razor Pages for Identity UI
			app.MapRazorPages();

			// Ensure the database is migrated and roles are seeded when the app starts
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider; // Get service provider from scope
				var context = services.GetRequiredService<ApplicationDbContext>(); // Retrieve the database context
				context.Database.Migrate(); // Apply any pending migrations
				SeedRoles(services).Wait(); // Seed roles into the database
			}

			app.Run(); // Start the web application
		}

		// Seed roles into the database during application startup
		private static async Task SeedRoles(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>(); // Retrieve RoleManager

			string[] roles = { "Lecturer", "Manager", "Co-ordinator" }; // Define roles

			// Check if each role exists; if not, create it
			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
				{
					await roleManager.CreateAsync(new IdentityRole(role)); // Create the role if it doesn't exist
				}
			}
		}
	}
}
