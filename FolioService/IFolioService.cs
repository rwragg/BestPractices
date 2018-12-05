using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using FolioLibrary.Data;

namespace FolioService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFolioService" in both code and config file together.
    [ServiceContract]
    public interface IFolioService
    {
        [OperationContract]
        FolioDTO GetFolioStatus(Int32 folio, int broker);
    }
}
