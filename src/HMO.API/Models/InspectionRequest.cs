using HMO.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace HMO.API.Models
{
    public class InspectionRequest
    {
        [Required]
        public int InspectionId { get; set; }
        public string Status { get; set; }
        public Tenant Tenant { get; set; }
        public Address Address { get; set; }
        public RiskAssessmentForm RiskAssessmentForm { get; set; }
        public ServiceRequestForm ServiceRequestForm { get; set; }
        public HmoVerificationForm HmoVerificationForm { get; set; }
    }
}
