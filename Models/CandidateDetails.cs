using System.ComponentModel.DataAnnotations;

namespace ManagementAPI.Models
{
    public class CandidateDetails
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="First Name")]
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage = "Please enter your last name")]
        public string LastName {get;set;}
        [Display(Name ="Start Date")]
        public DateTime StartDate {get;set;}
        [Display(Name ="End Date")]
        public DateTime EndDate {get;set;}
        public CandidateType type{get;set;}
        
    }
    public enum CandidateType
    {
        Hybrid, Remote, OfficeBased
    }
}