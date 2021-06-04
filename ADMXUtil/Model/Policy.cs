using System.Xml;
using System.Xml.Linq;

namespace ADMXUtil.Model
{
    public class Policy
    {

        public Policy(XElement elem, ADML adml)
        {
            Name = elem.Attribute("name").Value;

            Class = elem.Attribute("class").Value switch
            {
                "Both" => PolicyClass.Both,
                "Machine" => PolicyClass.Machine,
                "User" => PolicyClass.User,
                _ => throw new XmlException()
            };

            DisplayNameId = elem.Attribute("displayName").Value.Replace("$(string.", "").TrimEnd(')');
            DisplayName = adml.ConvertString(DisplayNameId);
            ExplainTextId = elem.Attribute("explainText").Value.Replace("$(string.", "").TrimEnd(')');
            ExplainText = adml.ConvertString(ExplainTextId);
            Key = elem.Attribute("key")?.Value ?? string.Empty;
            ValueName = elem.Attribute("valueName")?.Value ?? string.Empty;
            ADMLContent = elem.ToString();
        }

        public string ToCSVRecord()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"",
                Name, Class, DisplayNameId, DisplayName,
                ExplainTextId, ExplainText, Key, ValueName, RegistryPath);
        }

        public string ToCSVHeader()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                "Name", "Class", "DisplayNameId", "DisplayName",
                "ExplainTextId", "ExplainText", "Key", "ValueName", "RegistryPath");
        }

        public string Name { get; private set; }
        public PolicyClass Class { get; private set; }
        public string DisplayNameId { get; private set; }
        public string DisplayName { get; private set; }
        public string ExplainTextId { get; private set; }
        public string ExplainText { get; private set; }
        public string Key { get; private set; }
        public string ValueName { get; private set; }
        public string RegistryPath
        {
            get
            {
                if (string.IsNullOrEmpty(Key)) return string.Empty;
                if (string.IsNullOrEmpty(ValueName)) return Key;
                return Key +"\\"+ ValueName;
            }
        }

        public string ADMLContent { get; private set; }
    }

    public enum PolicyClass
    {
        User,
        Machine,
        Both
    }
}