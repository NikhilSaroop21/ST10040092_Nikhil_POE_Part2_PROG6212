using Microsoft.AspNetCore.Mvc; // Provides classes and attributes for MVC
using Microsoft.AspNetCore.Authorization; // For authorization functionality (if needed)
using Microsoft.AspNetCore.Identity; // Identity classes for role management

namespace ST10040092_Nikhil_POE_Part2_PROG6212.Controllers
{
	// Controller to manage application roles
	public class AppRolesController : Controller
	{
		// Dependency injection for RoleManager to manage Identity roles
		private readonly RoleManager<IdentityRole> _roleManager;

		// Constructor to inject RoleManager dependency
		public AppRolesController(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager; // Assign injected RoleManager to the private field
		}

		// Action to display a list of all roles
		public IActionResult Index()
		{
			var roles = _roleManager.Roles; // Retrieve all roles from the RoleManager
			return View(roles); // Pass the roles to the view for display
		}

		// GET: Action to display the Create Role form
		[HttpGet] // Indicates this action responds to GET requests
		public IActionResult Create()
		{
			return View(); // Return the Create view for role creation
		}

		// POST: Action to create a new role
		[HttpPost] // Indicates this action responds to POST requests
		public async Task<IActionResult> Create(IdentityRole model)
		{
			// Check if the role already exists
			if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
			{
				// Create the role if it does not exist
				_roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
			}

			// Redirect to the Index action to display the list of roles
			return RedirectToAction("Index");
		}
	}
}
// code attribution // W3schools // https://www.w3schools.com/cs/index.php

// code attribution //Microsoft //https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started

// code attribution //Microsoft //https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-dotnet-get-started?tabs=azure-ad

// code attribution //Bootswatch //https://bootswatch.com/
