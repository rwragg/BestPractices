using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Sybase.Data.AseClient;

using FolioLibrary.Utility;
using System.Runtime.Serialization;

namespace FolioLibrary.Data
{
    [DataContract]
    public class FolioDTO
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SP_READ = "sp_Folio_Status";

        //Public property for the object
        //Utilized by NuGet: Dapper
        [DataMember]
        public String Status { get; set; }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public FolioDTO Read(Int32 _folio, int _broker)
        {
            //parameters for the stored procedure call
            var items = new { folio = _folio, broker = _broker };

            PGDBAccess dbAccessor = new PGDBAccess();

            FolioDTO d = dbAccessor.ExecuteScalar(SP_READ, this, items);
            return d;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
