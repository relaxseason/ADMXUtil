using ADMXUtil.Model;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Xunit;
using Xunit.Sdk;

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
        public void Load_InputIsTempFilePath_throwException()
        {
            var tmpAdmxFile = Path.GetTempFileName();
            var tmpAdmlFile = Path.GetTempFileName();
            var result = Assert.Throws<XmlException>(() =>
            {
                _admxUtil.Policies(tmpAdmxFile,tmpAdmlFile);
            });
            File.Delete(tmpAdmlFile);
            File.Delete(tmpAdmxFile);
        }

        [Fact]
        public void Load_InputIsXMLFilePath_ReturnPoilcyArray()
        {
            var admxFile = Path.Combine(".","ExampleData","ADMXExample.admx");
            var admlFile = Path.Combine(".", "ExampleData", "ADMLExample.adml");
            var result = _admxUtil.Policies(admxFile, admlFile);
            Assert.IsType<List<Policy>>(result);
            Assert.Equal(17,result.Count);
        }

    }


}
