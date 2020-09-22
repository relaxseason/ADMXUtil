using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ADMXUtil.Model
{
    public class ADMX
    {
        private XElement admxDoc;
        private ADML adml;

        public ADMX(XElement admxDoc, ADML adml)
        {
            this.admxDoc = admxDoc;
            this.adml = adml;
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
            XNamespace ns = admxDoc.GetDefaultNamespace();
            var policyElem = from el in admxDoc.Elements().Elements(ns + "policy")
                             select el;
            foreach (var elem in policyElem)
            {
                result.Add(new Policy(elem, adml));
            }

            return result;
        }

        private List<Policy> _policies;


    }
}
