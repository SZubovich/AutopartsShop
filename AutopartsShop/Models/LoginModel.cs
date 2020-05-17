using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutopartsShop.Models
{
    public class LoginModel : DefaultPageModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не введён пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
