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
    public class BusinessModel
    {
        private IRepository<Models> _modelRepository;
        private IUnitOfWork _modelUnitOfWork;
        private DbContext _dbContext;

        public BusinessModel()
        {
            _dbContext = new ProductInformationEntities();
            _modelUnitOfWork = new EFUnitOfWork(_dbContext);
            _modelRepository = _modelUnitOfWork.GetRepository<Models>();
        }

        public List<Models> GetModels()
        {
            return _modelRepository.GetAll().ToList();
        }

        public void Add(Models _model)
        {
            _modelRepository.Insert(_model);
            _modelUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _modelRepository.Delete(ID);
            _modelUnitOfWork.SaveChanges();
        }

        public void Edit(Models _model)
        {
            var model = _modelRepository.GetById(_model.ModelID);

            model.BrandID = _model.BrandID;
            model.Model = _model.Model;
            _modelRepository.Update(model);
            _modelUnitOfWork.SaveChanges();
        }

        public Models GetModel(int ID)
        {
            return _modelRepository.Get(model => model.ModelID == ID);
        }

        private ProductInformationEntities db = new ProductInformationEntities();
        public List<Models> ListForComboBox()
        {
            List<Models> list = db.Models1.ToList();
            list.Insert(0, new Models { ModelID= 0, Model= "Seçiniz..." });
            return list;
        }

        public List<SP_ModelByBrand_Result> ModelByBrand()
        {
            return db.SP_ModelByBrand().ToList();
        }
    }
}
