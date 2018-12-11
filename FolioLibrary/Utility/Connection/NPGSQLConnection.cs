using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

using Npgsql;

namespace FolioLibrary.Utility.Connection
{
    internal class NPGSQLConnection : IConnection
    {
        private NpgsqlConnection _conn;

        public DbConnection Connection
        {
            get { return _conn; }
        }

        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        
        public void CreateOpenConnection()
        {
            String _dbConnString = null;

            try
            {
                _dbConnString =
                    ConfigurationManager.ConnectionStrings["Postgre_DB"].ConnectionString;
            }
            catch (ConfigurationErrorsException e)
            {
                log.Error("Error: Cannot get connection settings from the config file!!", e);
            }

            try
            {
                _conn = new NpgsqlConnection(_dbConnString);

                _conn.Open();
            }
            catch (NpgsqlException e)
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
