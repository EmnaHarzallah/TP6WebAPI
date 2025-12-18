using System.ComponentModel.DataAnnotations;

namespace TP6WebAPI.Models.Auth
{
    public class RegisterCredentials
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Email { get; set; }
    }
}