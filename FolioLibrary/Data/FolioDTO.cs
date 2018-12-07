using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Sybase.Data.AseClient;

using FolioLibrary.Utility;
using FolioLibrary.Utility.Connection;

namespace FolioLibrary.Data
{
    [DataContract]
    public class FolioDTO
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SP_READ = "sp_folio_status";

        //Public property for the object
        //Utilized by NuGet: Dapper
        [DataMember]
        public String Status { get; set; }

        [DataMember]
        public String Phase { get; set; }

        internal void Create()
        {
            throw new NotImplementedException();
        }

        internal void Delete()
        {
            throw new NotImplementedException();
        }

        internal FolioDTO Read(Int32 _folio, Int32 _broker)
        {
            //parameters for the stored procedure call
            var items = new { Folio = _folio, Broker = _broker };

            DBAccess dbAccessor = new DBAccess();

            //set the connection type
            dbAccessor.Connection = new ASESQLConnection();

            FolioDTO d = dbAccessor.ExecuteSP(SP_READ, this, items);
            return d;
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }
    }
}
