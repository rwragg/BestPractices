using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Autofac;

using FolioLibrary.Utility;
using FolioLibrary.Utility.Connection;
using FolioLibrary.Utility.Configuration;

namespace FolioLibrary.Data
{
    [DataContract]
    public class FolioDTO
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SP_READ = "sp_folio_detalle";

        private IContainer Container = new Configuration().Container;

        //Utilized by NuGet: Dapper
        [DataMember]
        public string Folio { get; set; }

        [DataMember]
        public string Txn { get; set; }

        [DataMember]
        public int Days { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public string LOB { get; set; }

        [DataMember]
        public string Internal_St { get; set; }

        [DataMember]
        public string External_St { get; set; }

        [DataMember]
        public string Real_St { get; set; }

        internal void Create()
        {
            throw new NotImplementedException();
        }

        internal void Delete()
        {
            throw new NotImplementedException();
        }

        internal FolioDTO Read(Int32 _folio)
        {
            //parameters for the stored procedure call
            var items = new { Folio = _folio};

            using (var scope = Container.BeginLifetimeScope())
            {
                DBAccess dbAccessor = new DBAccess(scope.Resolve<IConnection>());
                FolioDTO d = dbAccessor.ExecuteSP(SP_READ, this, items);

                return d;
            }
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            String s = $"Folio: {Folio} Txn: {Txn} Days: {Days} Producer: {Producer} LOB: {LOB} " +
                $"Internal State: {Internal_St} External State: {External_St} Real State: {Real_St}";

            return s;
        }
    }
}
