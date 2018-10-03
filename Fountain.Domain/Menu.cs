using Fountain.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain.Domain
{
    public class Menu:BaseDomain
    {
        public int ParentMenuId { get; set; }
        [MaxLength(100)]
        public string MenuName { get; set; }
        [MaxLength(100)]
        public string MenuLink { get; set; }
    }
}
