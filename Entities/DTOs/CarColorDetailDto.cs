using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarColorDetailDto : IDto
    {
        public int ColorID { get; set; }
        public int CarID { get; set; }
        public int RentalID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}