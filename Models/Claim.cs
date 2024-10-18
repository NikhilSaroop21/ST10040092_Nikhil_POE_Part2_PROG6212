using System.ComponentModel.DataAnnotations; // For data validation attributes
using System.ComponentModel.DataAnnotations.Schema; // For additional database mapping configurations

namespace ST10040092_Nikhil_POE_Part2_PROG6212.Models
{
	public class Claim
	{
		// Primary Key
		[Key] // Marks ClaimId as the primary key for the Claim table
		public int ClaimId { get; set; } // Unique identifier for each claim

		// Lecturer Name (Required Field)
		[Required] // Ensures that the LecturerName is mandatory
		public string LecturerName { get; set; } // Stores the name of the lecturer submitting the claim

		// Hours Worked (Required and Range Validation)
		[Required] // Marks HoursWorked as a required field
		[Range(0, double.MaxValue)] // Ensures the value is non-negative
		public double HoursWorked { get; set; } // Stores the number of hours worked




		// Hourly Rate (Required and Range Validation)
		[Required] // Marks HourlyRate as a required field
		[Range(0, double.MaxValue)] // Ensures the rate is non-negative
		public double HourlyRate { get; set; } // Stores the hourly rate for the lecturer




		// Additional Notes (Optional)
		public string Notes { get; set; } // Stores optional notes related to the claim

		// Claim Status (Required with Default Value)
		[Required] // Ensures Status is mandatory
		public string Status { get; set; } = "Stand By"; // Default status is "Stand By"

		// Document Path (Required)
		[Required] // Ensures that a document path is provided
		public string? DocumentPath { get; set; } // Stores the file path of the uploaded document (nullable)
	}
}
