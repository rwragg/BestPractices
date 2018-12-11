using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Autofac;

using FolioLibrary.Utility.Connection;

namespace FolioLibrary.Utility.Configuration
{
    class Configuration
    {
        static ContainerBuilder builder;

        private static IContainer container;
        internal IContainer Container
        {
            get
            {
                return container;
            }
        }

        static Configuration()
        {
            builder = new ContainerBuilder();

            // Register the database connection.  Currently Postgres or Sybase
            builder.Register<IConnection>(x =>
            {
                string s = ConfigurationManager.AppSettings["db"];

                if (s == "sise")
                {
                    return new ASESQLConnection();
                }
                else
                {
                    return new NPGSQLConnection();
                }
            });

            container = builder.Build();
        }
    }
}
