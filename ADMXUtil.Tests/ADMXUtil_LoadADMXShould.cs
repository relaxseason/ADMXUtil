using System.Collections.Generic;
using System.IO;
using Xunit;

namespace ADMXUtil.Tests
{
    public class ADMXUtil_LoadADMXShould
    {
        private readonly ADMXUtil _admxUtil;
        public ADMXUtil_LoadADMXShould()
        {
            _admxUtil = new ADMXUtil();
        }

        [Fact]
        public void Load_InputIsFilePath_ReturnPoilcyArray()
        {
            var tmpFile = Path.GetTempFileName();
            var result = _admxUtil.Load(tmpFile);
            Assert.IsType<List<Policy>>(result);

        }
    }

    
}
