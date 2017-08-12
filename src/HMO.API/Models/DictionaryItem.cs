using System.Xml.Serialization;

namespace HMO.API.Models
{
    public class DictionaryItem
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
