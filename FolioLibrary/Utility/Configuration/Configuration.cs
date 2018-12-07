using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;

using FolioLibrary.Utility.Connection;

namespace FolioLibrary.Utility.Configuration
{
    class Configuration
    {
        static ContainerBuilder builder;

        static IContainer container;
        public IContainer Container
        {
            get { return container; }
        }

        static Configuration()
        {
            builder = new ContainerBuilder();

            builder.RegisterType<ASESQLConnection>().As<IConnection>();

            container = builder.Build();
        }
    }
}
