using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalCompanyContext>, IUserDal
    {
        public List<CustomerRentalDetailDto> GetCustomerAndRentalDetails()
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var result = from c in context.Customers
                             join r in context.Rentals
                                 on c.CustomerID equals r.CustomerID
                             join u in context.Users
                                 on c.CustomerID equals u.Id
                             select new CustomerRentalDetailDto()
                             {
                                 RentalID = r.RentalID,
                                 UserID = u.Id,
                                 CustomerID = c.CustomerID,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();

            }
        }

        public bool DeleteUserIfNotReturnDateNull(User user)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var find = GetCustomerAndRentalDetails().Any(i => i.UserID == user.Id && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(user);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = userOperationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };

                return result.ToList();
            }

        }
    }
}