﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim alanı boş geçilemez!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı boş geçilemez!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş geçilemez!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email alanı boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Email formatına uygun değil!")]
        public string Email { get; set; }
    }
}
