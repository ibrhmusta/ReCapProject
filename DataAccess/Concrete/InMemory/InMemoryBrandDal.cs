using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandID = 1, BrandName= "Citroen", BrandModel = "DS7 Crossback"},
                new Brand{BrandID = 2, BrandName= "Jeep", BrandModel = "Renegade"},
                new Brand{BrandID = 3, BrandName= "Mini Cooper", BrandModel = "Countryman"},
                new Brand{BrandID = 4, BrandName= "Audi", BrandModel = "A3"},
                new Brand{BrandID = 1, BrandName= "Mercedes", BrandModel = "CLA"}
            };
        }
        public void Add(Brand entity)
        {
            _brands.Add(entity);    
        }

        public void Delete(Brand entity)
        {
            Brand colorToDelete = _brands.SingleOrDefault(b => b.BrandID == entity.BrandID);
            _brands.Remove(colorToDelete);
        }

        public Brand Get(Func<Brand, bool> filter = null)
        {
            return _brands.SingleOrDefault(filter);
        }


        public List<Brand> GetAll(Func<Brand, bool> filter = null)
        {
            return _brands.Where(filter).ToList();
        }

        public List<CarBrandDetailDto> GetCarAndBrandDetails()
        {
            throw new NotImplementedException();
        }

        public bool DeleteBrandIfNotReturnDateNull(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandID == entity.BrandID);
            brandToUpdate.BrandID = entity.BrandID;
            brandToUpdate.BrandName = entity.BrandName;
            brandToUpdate.BrandModel = entity.BrandModel;
        }
    }
}
