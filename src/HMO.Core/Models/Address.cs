﻿namespace HMO.Core.Models
{
    public class Address
    {
        public int PropertyId { get; set; }
        public string HouseName { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string AddLine1 { get; set; }
        public string AddLine2 { get; set; }
        public string PostCode { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}