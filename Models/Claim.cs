using System.ComponentModel.DataAnnotations; // For data validation attributes
using System.ComponentModel.DataAnnotations.Schema; // For additional database mapping configurations

namespace ST10040092_Nikhil_POE_Part2_PROG6212.Models
{
	public class Claim
	{

        // Primary key for the Claim entity.
        [Key]
        public int ClaimId { get; set; }

        // Stores the name of the lecturer submitting the claim.
        // This field is required and will be displayed as 'Lecturer' on the form.
        [Required]
        [Display(Name = "Lecturer")]
        public string LecturerName { get; set; }

        // Number of hours worked for the claim.
        // This field is required and must be a non-negative value.
        [Required]
        [Range(0, double.MaxValue)]
        public double HoursWorked { get; set; }

        // Hourly rate for the claim.
        // This field is required and must be a non-negative value.
        [Required]
        [Range(0, double.MaxValue)]
        public double HourlyRate { get; set; }

        // Calculate FinalPayment dynamically
        public decimal FinalPayment
        {
            get
            {
                return (decimal)(HoursWorked * HourlyRate);
            }
        }
        [Display(Name = "Additional Notes")]
        public string Notes { get; set; }

        // Status of the claim (e.g., 'Pending', 'Approved', or 'Rejected').
        // Default value is 'Pending'. This field is required.
        [Required]
        public string Status { get; set; } = "Pending";


        public string? DeclinedReason { get; set; }

        // Path to the supporting document uploaded for the claim.
        // This field is required and stores the location of the uploaded file.
        [Required]
        public string? DocumentPath { get; set; }

        public string UserId { get; set; }
    }
}
