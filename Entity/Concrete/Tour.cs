using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;
namespace Entity.Concrete
{
    public class Tour : IEntity
    {
        public int Id { get; set; } //1
        public string Name { get; set; } //2025 Hac Programý - Rayhaan
        public string TourUrl { get; set; } //rayhan-hac
        public string DepartureDate { get; set; } //31 mayýs
        public string DepartureCity { get; set; } //Ýstanbul 
        public string DestinationCity { get; set; } //Cidde
        public string? IntermediatePassageDate { get; set; } //11 Haziran
        public string? IntermediatePassageFirstCity { get; set; } //Mekke
        public string? IntermediatePassageSecondCity { get; set; } //Medine
        public string ReturningDate { get; set; } //13 Haziran
        public string ReturningDepartureCity { get; set; } //Medine
        public string ReturningDestinationCity { get; set; } //Ýstanbul
        public string FirstHotel { get; set; } // Reyhan Rotana
        public string SecondHotel { get; set; } // Dar al Taqwa
        public decimal PriceForTwoRoom { get; set; } //18500$
        public decimal PriceForThreeRoom { get; set; } //18000$

    }
}
