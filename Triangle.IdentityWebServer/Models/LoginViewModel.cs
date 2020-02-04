using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Triangle.IdentityWebServer.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name Is Missing")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password Is Missing")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
