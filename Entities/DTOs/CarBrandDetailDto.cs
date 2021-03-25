using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarBrandDetailDto : IDto
    {
        public int BrandID { get; set; }
        public int CarID { get; set; }
        public int RentalID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
