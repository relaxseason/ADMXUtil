using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ADMXUtil
{
    public class ADML
    {
        public ADML(XElement admlDoc)
        {
            this.admlDoc = admlDoc;
            XNamespace ns = admlDoc.GetDefaultNamespace();
            var stringElem = from el in admlDoc.Elements().Elements().Elements(ns + "string") select el;
            foreach (var elem in stringElem)
            {
                var id = elem.Attribute("id").Value;
                var value = elem.Value;
                StringTable.Add(id, value);
            }

        }
        private Dictionary<string, string> StringTable = new Dictionary<string, string>();

        private XElement admlDoc;

        internal string ConvertString(string stringId)
        {
            return StringTable[stringId];
        }
    }
}
