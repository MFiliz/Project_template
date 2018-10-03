using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fountain.Domain.BaseClass;

namespace Fountain.Domain
{
    public class User : BaseDomain
    {
        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(11)]
        public string TcKimlikNumber { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime JobStartDate { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }

        [StringLength(10)]
        public string CellPhone { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        public string Password { get; set; }

        public bool IsFirstLogin { get; set; }

        public string ForgotPasswordKey { get; set; }
        public DateTime? ForgotPasswordKeyCreateTime { get; set; }

        
        public virtual int? SellerId { get; set; }
    }
}