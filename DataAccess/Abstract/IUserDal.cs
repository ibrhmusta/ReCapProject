using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal :IEntityRepository<User>
    {
        //List<CustomerRentalDetailDto> GetRentalAndCustomerDetails();
        //List<UserDetailDto> GetUserAndCustomerDetails();
        //List<CustomerRentalDetailDto> GetCustomerAndRentalDetails();
        bool DeleteUserIfNotReturnDateNull(User user);
        List<OperationClaim> GetClaims(User user);

    
    }
}
