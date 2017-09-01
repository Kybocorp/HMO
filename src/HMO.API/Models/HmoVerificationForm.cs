using System;
using System.Collections.Generic;

namespace HMO.API.Models
{
    public class HmoVerificationForm
    {
        public int LicenceTypeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<int> PropertyDescription { get; set; }
        public int Storeys { get; set; }
        public int NumberOfWhbs { get; set; }
        public int NumberOfOccupants { get; set; }
        public int FireProtection { get; set; }
        public string FireProtectionDescription { get; set; }
        public bool CorrectFeePaid { get; set; }
        public bool AccreditationProof { get; set; }
        public decimal RefundAmount { get; set; }
        public decimal OutstandingAmount { get; set; }
        public List<Room> Rooms { get; set; }
        public List<byte[]> EvidenceImages { get; set; }
    }
}
