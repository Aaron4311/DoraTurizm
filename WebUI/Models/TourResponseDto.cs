namespace WebUI.Models
{
    public class TourResponseDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string TourUrl { get; set; } 
        public string DepartureDate { get; set; } 
        public string DepartureCity { get; set; } 
        public string DestinationCity { get; set; }
        public string? IntermediatePassageDate { get; set; } 
        public string? IntermediatePassageFirstCity { get; set; } 
        public string? IntermediatePassageSecondCity { get; set; } 
        public string ReturningDate { get; set; } 
        public string ReturningDepartureCity { get; set; } 
        public string ReturningDestinationCity { get; set; }
        public string FirstHotel { get; set; } 
        public string SecondHotel { get; set; } 
        public decimal PriceForTwoRoom { get; set; } 
        public decimal PriceForThreeRoom { get; set; } 
    }
}
