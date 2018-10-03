using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain.Helper.BaseClassHelper
{
   public class ListCountValidatorAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as List<string>;
            if (list != null )
            {
                return list.Count > 0;
            }
            return false;
        }
    }
}
