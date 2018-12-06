using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sybase.Data.AseClient;

namespace FolioLibrary.Utility
{
    interface IDataAccess
    {
        T ExecuteSP<T>(String spName, T dto, Object items);
    }
}
