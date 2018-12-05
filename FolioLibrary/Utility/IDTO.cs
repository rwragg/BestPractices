using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolioLibrary.Utility
{
    interface IDTO
    {
        void Create();
        T Read<T>();
        void Update();
        void Delete();
    }
}
