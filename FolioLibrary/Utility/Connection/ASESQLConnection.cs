using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sybase.Data.AseClient;

namespace FolioLibrary.Utility.Connection
{
    internal class ASESQLConnection : IConnection
    {
        private AseConnection _conn;
        public DbConnection Connection
        {
            get { return _conn; }
        }

        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(
               System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void CreateOpenConnection()
        {
            String _dbConnString = null;

            try
            {
                _dbConnString =
                    ConfigurationManager.ConnectionStrings["SISE_DB"].ConnectionString;
            }
            catch (ConfigurationErrorsException e)
            {
                log.Error("Error: Cannot get connection settings from the config file!!", e);
            }

            try
            {
                //_conn = new AseConnection(_dbConnString);
                _conn = new AseConnection(_dbConnString);

                _conn.Open();
            }
            catch (AseException e)
            {
                log.Error("Error: connecting to the database!", e);
            }

            if (_conn == null || _conn.State !=
                ConnectionState.Open)
            {
                log.Error("Error: connection is null!");
            }
        }

    }
}
