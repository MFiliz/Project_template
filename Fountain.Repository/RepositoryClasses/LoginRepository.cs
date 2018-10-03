using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Fountain.Domain;
using Fountain.DTO.Login;
using Fountain.Helper;
using Fountain.Repository.IOC;
using Fountain.Repository.RepositoryInterfaces;

namespace Fountain.Repository.RepositoryClasses
{
    public class LoginRepository : ILoginRepository
    {
        public LoginDto LoginUser(LoginDto userDto)
        {
            var user =
                Repositories.UnitOfWorkCurrent.Users.FirstOrDefault(
                    x => x.EMail == userDto.EMail && x.Password == userDto.Password && x.IsActive && !x.IsDeleted );
            if (user != null)
                return new LoginDto
                {
                    EMail = user.EMail,
                    Id = user.Id,
                    FullName = user.FullName,
                    CellPhone = user.CellPhone,
                    IsLogin = true,
                    SellerId = user.SellerId.Value,
                    IsFirstLogin = user.IsFirstLogin
                };
            return null;
        }

        public bool IsUserExist(string mail)
        {
            var user =
                Repositories.UnitOfWorkCurrent.Users.FirstOrDefault(x => x.EMail == mail && x.IsActive && !x.IsDeleted);
            return user != null;
        }
    }
}