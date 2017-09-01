using HMO.Core.Models;
using System.Collections.Generic;

namespace HMO.API.Models
{
    public class ServiceRequestForm
    {
        public Contact Owner { get; set; }
        public Contact Agent { get; set; }
        public bool RequiresLicense { get; set; }
        public bool ComplaintClosed { get; set; }
        public int NoticeId { get; set; }
        public string Note { get; set; }
        public List<byte[]> EvidenceImages { get; set; }
    }
}
