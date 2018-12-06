using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

using Npgsql;
using Dapper;


namespace FolioLibrary.Utility
{
    internal class PGDBAccess : IDataAccess
    {
        private NpgsqlConnection _conn = null;

        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void CreateOpenConnection()
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
                //_conn = new AseConnection(_dbConnString);
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
