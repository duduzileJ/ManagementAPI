using System.ComponentModel.DataAnnotations;

namespace ManagementAPI.Models
{
    public class Register
    {
        [Required, MaxLength(50)]
        public string EmailAddress {get;set;}
        [Required,DataType(DataType.Password)]
        public string Password{get;set;}
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword {get;set;}
    }
}