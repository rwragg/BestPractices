using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using FolioLibrary.Data;

namespace FolioService
{
    public class FolioService : IFolioService
    {
        FolioDTO IFolioService.GetFolioStatus(Int32 folio, int broker)
        {
            FolioDTO fd = new FolioDTO();
            fd = fd.Read(5191156, 78511);

            return fd;
        }
    }
}
