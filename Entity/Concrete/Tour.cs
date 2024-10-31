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
        public int Id { get; set; }
        public string Name { get; set; }
        public string TourUrl { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureAndDestinationCity { get; set; }
        public string? IntermediatePassageDate { get; set; }
        public string? IntermediatePassageCity { get; set; }
        public string ReturningDate { get; set; }
        public string ReturningDepartureAndDestinationCity { get; set; }
        public string Hotel { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
        public string[] ImageUrls { get; set; }
    }
}
