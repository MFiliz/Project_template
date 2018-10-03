using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fountain.DTO.Login;

namespace Fountain.Repository.RepositoryInterfaces
{
    public interface ILoginRepository
    {
        LoginDto LoginUser(LoginDto userDto);

        Boolean IsUserExist(string mail);

        
    }
}