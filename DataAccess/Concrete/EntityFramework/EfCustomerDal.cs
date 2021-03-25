using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalCompanyContext>, ICustomerDal
    {

        //public List<CustomerDetailDto> GetCustomerDetails()
        //{
        //    using (CarRentalCompanyContext context = new CarRentalCompanyContext())
        //    {
        //        var result = from u in context.Users
        //                     join c in context.Customers
        //                         on u.Id equals c.UserID
        //                     select new CustomerDetailDto
        //                     {
        //                         CustomerID = c.CustomerID,
        //                         CustomerInfo = $"{u.FirstName} {u.LastName}",
        //                         CompanyName = c.CompanyName
        //                     };
        //        return result.ToList();
        //    }
        //}

        public bool DeleteCustomerIfNotReturnDateNull(Customer customer)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var find = context.Rentals.Any(i => i.CustomerID == customer.CustomerID && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(customer);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}