using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.Dtos.Authentication
{
    public class UpdateUserDetailsDto
    {
        [Required]
        public string Id { get; set; }
        
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
