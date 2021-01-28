using BusinessLayer.Repository.Abstract;
using BusinessLayer.Repository.Concrete;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UnitOfWork.Business
{
    public class BusinessCountry
    {
        private IRepository<Country> _countryRepository;
        private IUnitOfWork _countryUnitOfWork;
        private DbContext _dbContext;

        public BusinessCountry()
        {
            _dbContext = new ProductInformationEntities();
            _countryUnitOfWork = new EFUnitOfWork(_dbContext);
            _countryRepository = _countryUnitOfWork.GetRepository<Country>();
        }

        public List<Country> GetCountries()
        {
            return _countryRepository.GetAll().ToList();
        }

        public void Add(Country _country)
        {
            _countryRepository.Insert(_country);
            _countryUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _countryRepository.Delete(ID);
            _countryUnitOfWork.SaveChanges();
        }

        public void Edit(Country _country)
        {
            var country = _countryRepository.GetById(_country.CountryID);

            country.CountryName = _country.CountryName;
            _countryRepository.Update(country);
            _countryUnitOfWork.SaveChanges();
        }

        public Country GetCountry(int ID)
        {
            return _countryRepository.Get(country => country.CountryID == ID);
        }

        private ProductInformationEntities db = new ProductInformationEntities();
        public List<Country> ListForComboBox()
        {
            List<Country> list = db.Countries.ToList();
            list.Insert(0, new Country { CountryID = 0, CountryName = "Seçiniz..." });
            return list;
        }
    }
}
