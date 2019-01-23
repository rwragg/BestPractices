using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using FolioLibrary.Data;
using FolioLibrary.Business;
using FolioLibrary.Utility.Configuration;

namespace FolioService
{
    public class FolioService : IFolioService
    {
        FolioDTO IFolioService.GetFolioStatus(Int32 folio)
        {
            Folio f = new Folio();
            return f.Read(folio);
        }
    }
}
