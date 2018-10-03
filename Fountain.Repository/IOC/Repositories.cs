using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fountain.Repository.Context;
using Fountain.Repository.RepositoryInterfaces;

namespace Fountain.Repository.IOC
{
    public class Repositories
    {
        public static ILoginRepository LoginRepository
        {
            get { return ServiceIoc.Container.Resolve<ILoginRepository>(); }
        }


        public static MyEnt UnitOfWorkCurrent
        {
            get { return ServiceIoc.Container.Resolve<MyEnt>(); }
        }
    }
}