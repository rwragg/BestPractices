﻿using System;
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
        public FolioService()
        {

        }

        static FolioService()
        {
            Configuration config = new Configuration();
        }

        FolioDTO IFolioService.GetFolioStatus(Int32 folio, int broker)
        {
            Folio f = new Folio();
            return f.Read(folio, broker);
        }
    }
}
