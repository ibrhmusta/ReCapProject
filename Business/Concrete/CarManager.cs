using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Filter;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }
        
        

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.CarID == carId), Messages.Listed);
        }

        
        
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.ColorID == colorId), Messages.Listed);
        }

        
        
        //[CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return  new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        
        
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator), Priority =1)]
        public IResult  Add(Car car)
        {
            if (car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.InvalidEntry);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
        }

        
        
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            var result = _carDal.DeleteCarIfNotReturnDateNull(car);
            if (result)
            {
                return new SuccessResult(Messages.Deleted);
            }

            return new ErrorResult(Messages.NotDeleted);
        }

        
        
        
        [ValidationAspect(typeof(CarValidator), Priority =1)]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        
        
        
        [TransactionScopeAspect]
        public IResult TransactionalTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandID == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorID == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorID == colorId && c.BrandID==brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCar(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=> c.CarID == carId));
        }

        public IDataResult<List<CarDetailDto>> GetWithDetails(FilterDto filter)
        {
            //Expression propertyExp, someValue, containsMethodExp, combinedExp;
            //Expression<Func<CarDetailDto, bool>> exp = c => true, oldExp;
            //MethodInfo method;

            //var parameterExp = Expression.Parameter(typeof(CarDetailDto), "type");
            //foreach (PropertyInfo propertyInfo in filter.GetType().GetProperties())
            //{
            //    if (propertyInfo.GetValue(filter,null) != null)
            //    {
            //        oldExp = exp;
            //        propertyExp = Expression.Property(parameterExp, propertyInfo.Name);
            //        method = typeof(object).GetMethod("Equals", new[] { typeof(object) });
            //        someValue = Expression.Constant(filter.GetType().GetProperty(propertyInfo.Name).GetValue(filter,null),typeof(object));
            //        containsMethodExp = Expression.Call(propertyExp, method, someValue);
            //        exp = Expression.Lambda<Func<CarDetailDto, bool>>(containsMethodExp, parameterExp);
            //        combinedExp = Expression.AndAlso(exp.Body, oldExp.Body);
            //        exp = Expression.Lambda<Func<CarDetailDto, bool>>(combinedExp, exp.Parameters[0]);
            //    }
            //}

            var exp = Filter.DynamicFilter<CarDetailDto, FilterDto>(filter);
            

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsFatih(exp));

        }
    }
}
