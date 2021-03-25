using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public string BrandName { get; set; }
        public string BrandModel { get; set; }
        public string ColorName { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }    
        public bool IsRentable { get; set; }
        public List<string> ImagePath { get; set; }
    }
}
