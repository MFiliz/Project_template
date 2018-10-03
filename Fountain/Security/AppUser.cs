using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Fountain.Security
{
    public class AppUser:ClaimsPrincipal
    {
        public AppUser(ClaimsPrincipal principal):base(principal)
        {
        }

        public string FirstName
        {
            get
            {
                try
                {
                    return this.FindFirst(ClaimTypes.Name).Value;
                }
                catch(Exception ee)
                {
                    return "";
                }
            }
        }

        public string Role
        {
            get
            {
                return this.FindFirst(ClaimTypes.Role).Value;
            }
        }

        public string Id
        {
            get
            {
                return this.FindFirst("Id").Value;
            }
        }

        public string SellerId
        {
            get
            {
                return this.FindFirst("SellerId").Value;
            }
        }

        public string EMailAddress
        {
            get
            {
                return this.FindFirst(ClaimTypes.Email).Value;
            }
        }

       

    }
}