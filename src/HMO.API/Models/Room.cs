namespace HMO.API.Models
{
    public class Room
    {
        public int Storey { get; set; }
        public int Location { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public int NumberOfPeople { get; set; }
        public string Notes { get; set; }
    }
}
