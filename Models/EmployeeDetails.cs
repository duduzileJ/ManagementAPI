using System.ComponentModel.DataAnnotations;

namespace ManagementAPI.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage = "Please enter your last name")]
        public string LastName {get;set;}
        [Display(Name = "Is Active?")]
        public bool isActive {get;set;}
    }
}