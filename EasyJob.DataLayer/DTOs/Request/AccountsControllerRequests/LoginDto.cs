using System.ComponentModel.DataAnnotations;

namespace EasyJob.DataLayer.DTOs.Request.AccountsControllerRequests
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}