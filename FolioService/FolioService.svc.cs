using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Autofac;

using FolioLibrary.Data;
using FolioLibrary.Business;
using FolioLibrary.Utility.Connection;

namespace FolioService
{
    public class FolioService : IFolioService
    {
        public FolioService()
        {

        }

        static FolioService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ASESQLConnection>().As<IConnection>();

            var container = builder.Build();
        }

        FolioDTO IFolioService.GetFolioStatus(Int32 folio, int broker)
        {
            Folio f = new Folio();
            return f.Read(folio, broker);
        }
    }
}
