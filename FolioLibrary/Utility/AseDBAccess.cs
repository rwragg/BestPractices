using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

using Dapper;
using Sybase.Data.AseClient;

namespace FolioLibrary.Utility
{
    internal class AseDBAccess : IDataAccess
    {
        //private AseConnection _conn;
        private AseConnection _conn = null;

        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(
               System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void CreateOpenConnection()
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

        /// <summary>
        /// Generic Method that auto-loads up T and returns it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="spName"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public T ExecuteSP<T>(String spName, T dto, Object items)
        {
            this.CreateOpenConnection();

            if (_conn == null)
            {
                log.Error("Connection is null!!");
                return default(T);
            }

            try
            {
                using (_conn)
                {
                    // NuGet Package: Dapper
                    // This call loads up the passed in T based on the database call
                    dto = _conn.QueryFirstOrDefault<T>(spName,
                        items,
                        commandType: CommandType.StoredProcedure);

                    return dto;
                }
            }
            catch (Exception e)
            {
                log.Error("Error: Error retrieving data!!", e);
                throw new Exception("Error: Error retrieving data!! " + e.Message);
            }
            finally
            {
                if (_conn != null)
                {
                    if (_conn.State == ConnectionState.Open)
                        _conn.Close();
                }
            }
        }
    }
}
