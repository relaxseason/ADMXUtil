using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ADMXUtil.Model
{
    class ADMX
    {
        private XElement admxDoc;
        private ADML adml;

        public ADMX(XElement admxDoc, XElement admlDoc)
        {
            this.admxDoc = admxDoc;
            this.adml = new ADML(admlDoc);
        }

        public List<Policy> Policies
        {
            get
            {
                if (_policies is null)
                {
                    _policies = LoadPolicies();
                }
                return _policies;
            }
        }

        private List<Policy> LoadPolicies()
        {
            var result = new List<Policy>();
            XNamespace ns = "http://schemas.microsoft.com/GroupPolicy/2006/07/PolicyDefinitions";
            var policyElem = from el in admxDoc.Elements().Elements(ns + "policy")
                             select el;
            foreach (var elem in policyElem)
            {
                result.Add(new Policy(elem));
            }

            return result;
        }

        private List<Policy> _policies;


    }
}
