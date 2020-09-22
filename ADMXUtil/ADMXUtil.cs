using ADMXUtil.Model;
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
        public List<Policy> Policies(string admxPath, string admlPath)
        {
            var admxDoc = LoadAdmx(admxPath);
            var admlDoc = LoadAdml(admlPath);
            var admx = new ADMX(admxDoc, admlDoc);
            return admx.Policies;
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
