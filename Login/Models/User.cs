using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class User
    {
        public int Id { get; set; } 
        [Display(Name ="Логин")]
        [Required(ErrorMessage ="Поле Логин должно быть заполнено")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле Email должно быть заполнено")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле Пароль должно быть заполнено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage ="Пароли должны совпадать")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}