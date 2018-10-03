using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain.DTO.Login
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Yeni şifre alanı boş bırakılamaz")]
        [StringLength(12, ErrorMessage = "Şifreniz en az 6, en çok 12 karakter olabilir.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre tekrar alanı boş bırakılamaz")]
        [StringLength(12, ErrorMessage = "Şifreniz en az 6, en çok 12 karakter olabilir.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Girilen şifreler uyumsuzdur. Kontrol ediniz.")]
        public string ReNewPassword { get; set; }


        public string UserEMail { get; set; }

        public string key { get; set; }
    }
}