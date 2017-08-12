using System.Xml.Serialization;

namespace HMO.API.Models
{
    public class DictionaryList
    {
        [XmlElement("DictionaryType")]
        public string DictionaryType { get; set; }
        [XmlElement("DictionaryItems")]
        public DictionaryItems DictionaryItems { get; set; }
    }
}
