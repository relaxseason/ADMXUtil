using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ADMXUtil
{
    class ADML
    {
        public ADML(XElement admlDoc)
        {
            this.admlDoc = admlDoc;
        }

        private XElement admlDoc;
    }
}
