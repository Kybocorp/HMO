using HMO.Core.Models;
using System;
using System.Collections.Generic;

namespace HMO.Infrastructure.Models
{
    public class Inspection
    {
        public int InspectionId { get; set; }
        public string InspectionTitle { get; set; }
        public string InspectionSubTitle { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Status { get; set; }
        public Officer Officer { get; set; }
        public Tenant Tenant { get; set; }
        public Address Address { get; set; }
        public bool RiskAssessmentForm { get; set; }
        public bool ServiceRequestForm { get; set; }
        public bool HMOVerificationForm { get; set; }
        public List<AddInfoItem> AddInfo { get; set; }
    }
}
