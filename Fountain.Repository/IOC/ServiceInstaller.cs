using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Fountain.Repository.Context;

namespace Fountain.Repository.IOC
{
    public class ServiceInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var dbRegistration =
                Component.For<MyEnt>().LifeStyle.PerWebRequest.UsingFactoryMethod(p => new MyEnt()).LifeStyle.Singleton;
            container.Register(dbRegistration);

            container.Register(
                Types.FromAssemblyNamed("Fountain.Repository")
                    .Where(t => t.Name.EndsWith("Repository"))
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient());
        }
    }
}
