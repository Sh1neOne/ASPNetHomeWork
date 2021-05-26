using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class UserLogin
    {
        [Required, MaxLength(20), Display(Name = "Логин")]
        public string LoginProp { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Пароль")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
