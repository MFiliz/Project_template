using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fountain.Domain;

namespace Fountain.DTO.Login
{
    public class LoginDto
    {
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "E-Posta Alanı Gereklidir")]
        [EmailAddress(ErrorMessage = "Geçersiz Bir E-Posta Adresi")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Gereklidir")]
        [MinLength(6, ErrorMessage = "Şifre Alanı 6 Karakterden Az Olamaz")]
        [MaxLength(12, ErrorMessage = "Şifre Alanı 12 Karakterden Fazla Olamaz")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<string> UserGroups { get; set; }
        public string FullName { get; set; }
        public string CellPhone { get; set; }
        public int Id{ get; set; }
        public bool IsLogin { get; set; }
        public bool IsFirstLogin { get; set; }


        public int SellerId { get; set; }
    }
}