using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using FolioLibrary.Data;

namespace FolioLibraryTest.Data
{
    public class FolioDTOTest
    {
        [Fact]
        public void FolioDTOReadTest()
        {
            FolioDTO fd = new FolioDTO();
            fd = fd.Read(5191156, 78511);

            Assert.Equal("EMITIDA", fd.Status);
        }
    }
}
