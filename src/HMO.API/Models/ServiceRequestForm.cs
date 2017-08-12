using HMO.Core.Models;
using System;
using System.Collections.Generic;

namespace HMO.API.Models
{
    public class ServiceRequestForm
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Contact Owner { get; set; }
        public Contact Agent { get; set; }
        public bool RequiresLicenceApp { get; set; }
        public bool ComplaintClosed { get; set; }
        public int NoticeId { get; set; }
        public string Notes { get; set; }
        public List<byte[]> EvidenceImages { get; set; }
    }
}
