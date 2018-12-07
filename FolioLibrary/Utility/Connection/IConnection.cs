using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;

namespace FolioLibrary.Utility.Connection
{
    internal interface IConnection
    {
        DbConnection Connection { get; }
        void CreateOpenConnection();
    }
}
