using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FolioLibrary.Data;

namespace FolioLibrary.Utility
{
    interface IDTO
    {
        void Create();
        FolioDTO Read(int folio, int broker);
        void Update();
        void Delete();
    }
}
