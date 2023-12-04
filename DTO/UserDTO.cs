using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="hghygygyuftfdt")]
        public string? Email { get; set; }
        [StringLength(50,ErrorMessage ="long")]
        public string? FirstName { get; set; }

        [StringLength(50, ErrorMessage = "long")]
        public string? LastName { get; set; }

        public string? Password { get; set; }
       
        
    }
}