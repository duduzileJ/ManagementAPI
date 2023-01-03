using System.ComponentModel.DataAnnotations;

namespace ManagementAPI.Models
{
    public class SignIn
    {
        [Required]
        public string Email {get;set;}
        [Required,DataType(DataType.Password)]
        public string Password {get;set;}
        public bool RememberMe {get;set;}
    }
    
}