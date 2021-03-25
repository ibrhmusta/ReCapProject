using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerRentalDetailDto
    {
        public int RentalID { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }


        
    }
}
