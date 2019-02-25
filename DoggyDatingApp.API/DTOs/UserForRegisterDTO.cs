using System.ComponentModel.DataAnnotations;

namespace DoggyDatingApp.API.DTOs
{
    public class UserForRegisterDTO
    {
        [Required]
         public string Username { get; set; }

        [Required]
         public string Password { get; set; }
    }
}