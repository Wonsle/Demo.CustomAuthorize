using System.ComponentModel.DataAnnotations;

namespace Demo.CustomAuthorize.Controllers
{
    public class LoginVM
    {
        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }
    }
}