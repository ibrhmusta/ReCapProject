using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalCompanyContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarID equals r.CarID
                             join b in context.Brands
                             on c.BrandID equals b.BrandID
                             join color in context.Colors
                             on c.ColorID equals color.ColorID
                             join cstmr in context.Customers
                             on r.CustomerID equals cstmr.CustomerID
                             select new RentalDetailDto
                             {
                                 RentalID = r.RentalID,
                                 CustomerID=cstmr.CustomerID,
                                 CarName = b.BrandName,
                                 ColorName = color.ColorName,
                                 CustomerInfo = $"{cstmr.FirstName} {cstmr.LastName}",
                                 CompanyName = cstmr.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();

            }
        }


        public bool DeleteRentalIfNotReturnDateNull(Rental rental)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var find = context.Rentals.Any(i => i.RentalID == rental.RentalID && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(rental);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }

        }
    }
}
