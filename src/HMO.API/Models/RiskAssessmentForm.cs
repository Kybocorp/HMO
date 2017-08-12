using System;
using System.Collections.Generic;

namespace HMO.API.Models
{
    public class RiskAssessmentForm
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PremisesType { get; set; }
        public int NumberOfResidents { get; set; }
        public int ManagementStandards { get; set; }
        public int HmoVulnerableResidents { get; set; }
        public int SingleFamilyVulnerableResidents { get; set; }
        public int DampAndMouldGrowth { get; set; }
        public int ExcessCold { get; set; }
        public int ExcessHeat { get; set; }
        public int Asbestos { get; set; }
        public int Biocides { get; set; }
        public int CarbonMonoxideAndFuel { get; set; }
        public int Lead { get; set; }
        public int Radiation { get; set; }
        public int UncombustedFuelGas { get; set; }
        public int VolatileOrganicCompounds { get; set; }
        public int CrowdingAndSpace { get; set; }
        public int EntryByIntruders { get; set; }
        public int Lighting { get; set; }
        public int NoiseProtection { get; set; }
        public int DomesticHygienePestsAndRefuse { get; set; }
        public int FoodSafety { get; set; }
        public int PersonalHygieneSanitationAndDrainage { get; set; }
        public int WaterSupplyForDomesticPurpose { get; set; }
        public int FallsAssociatedWithBaths { get; set; }
        public int FallingOnLevelSurfaces { get; set; }
        public int FallingOnStairs { get; set; }
        public int FallingBetweenLevels { get; set; }
        public int ElectricalHazards { get; set; }
        public int Fire { get; set; }
        public int FlamesHotSurfaces { get; set; }
        public int CollisionAndEntrapment { get; set; }
        public int Explosions { get; set; }
        public int PositionAndOperabilityOfAmenities { get; set; }
        public int StructuralCollapseAndFailingElements { get; set; }
        public List<byte[]> EvidenceImages { get; set; }
    }
}
