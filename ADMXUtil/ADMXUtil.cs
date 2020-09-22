using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADMXUtil
{
    public class ADMXUtil
    {
        public List<Policy> Load(string admxPath, string admlPath)
        {
            var admx = LoadAdmx(admxPath);
            var adml = LoadAdml(admlPath);
            return new List<Policy>() { new Policy() };
        }

        private  XElement LoadAdmx(string admxPath)
        {
            var absPath = Path.GetFullPath(admxPath);
            return XElement.Load(absPath);
        }


        private XElement LoadAdml(string admlPath)
        {
            var absPath = Path.GetFullPath(admlPath);
            return XElement.Load(absPath);
        }

    }
}
