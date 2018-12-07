using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

using FolioLibrary.Utility.Connection;

using Dapper;


namespace FolioLibrary.Utility
{
    internal class DBAccess : IDataAccess
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(
               System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IConnection _connection;
        public IConnection Connection 
        {
            set {_connection = value;}
        }

        /// <summary>
        /// Generic Method that auto-loads up T and returns it.
        /// </summary>
        /// <typeparam name="T">T = DTO</typeparam>
        /// <param name="spName">Stored Procedure name.</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public T ExecuteSP<T>(String spName, T dto, Object items)
        {
            if (_connection  == null)
            {
                log.Error("Connection must be set!");
                return default(T);
            }

            _connection.CreateOpenConnection();

            if (_connection.Connection == null)
            {
                log.Error("Connection is null!!");
                return default(T);
            }

            try
            {
                using (_connection.Connection)
                {
                    //dapper
                    dto = _connection.Connection.QueryFirstOrDefault<T>(spName,
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
                if (_connection.Connection != null)
                {
                    if (_connection.Connection.State == ConnectionState.Open)
                        _connection.Connection.Close();
                }
            }
        }
    }
}
