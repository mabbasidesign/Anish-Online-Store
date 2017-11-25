using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Anish.Models
{
    public class LoginViewModels
    {
        [Required(ErrorMessage = "plese enter username")]

        public string UserName { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "plese enter password")]
        public string Password { get; set; }

    }
}