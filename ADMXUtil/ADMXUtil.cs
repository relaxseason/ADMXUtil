using ADMXUtil.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Linq;
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
            var adml = new ADML(admlDoc);
            var admx = new ADMX(admxDoc, adml);

            return admx.Policies;
        }

        public void WriteCSV(string writePath, List<Policy> policyList)
        {
            var header = policyList.FirstOrDefault().ToCSVHeader();
            var contents = header + "\r\n" +
                  (from policy in policyList
                   select policy.ToCSVRecord()
                  )
                  .Aggregate<string>((first, second) => first + "\r\n" + second);
            if (!File.Exists(writePath))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                File.WriteAllText(writePath, contents, Encoding.GetEncoding("shift_jis"));
            }

        }

        private XElement LoadAdmx(string admxPath)
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
