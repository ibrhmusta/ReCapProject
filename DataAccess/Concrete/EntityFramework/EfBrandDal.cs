using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentalCompanyContext> , IBrandDal
    {
        public List<CarBrandDetailDto> GetCarAndBrandDetails()
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandID equals b.BrandID
                             join r in context.Rentals
                             on c.CarID equals r.CarID
                             select new CarBrandDetailDto
                             {
                                 CarID = c.CarID,
                                 BrandID = b.BrandID,
                                 RentalID = r.RentalID,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();

            }
        }
        
        public bool DeleteBrandIfNotReturnDateNull(Brand brand)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var find = GetCarAndBrandDetails().Any(i => i.BrandID == brand.BrandID && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(brand);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
