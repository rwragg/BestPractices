using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FolioLibrary.Data;
using FolioLibrary.Utility;

namespace FolioLibrary.Business
{
    public class Folio : IDTO
    {
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public FolioDTO Read(int folio, int broker)
        {
            FolioDTO fd = new FolioDTO();
            fd = fd.Read(5191156, 78511);

            return fd;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
