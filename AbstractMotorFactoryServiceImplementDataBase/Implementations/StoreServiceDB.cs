using AbstractMotorFactoryModel;
using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryServiceImplementDataBase.Implementations
{
    public class StoreServiceDB : IStoreService
    {
        private AbstractDbContext context;
        public StoreServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<StoreViewModel> GetList()
        {
            List<StoreViewModel> result = context.Stores.Select(rec => new
           StoreViewModel
            {
                Id = rec.Id,
                StoreName = rec.StockName
            })
            .ToList();
            return result;
        }
        public StoreViewModel GetElement(int id)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StoreViewModel
                {
                    Id = element.Id,
                    StoreName = element.StockName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StoreBindingModel model)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.StockName ==
           model.StoreName);
            if (element != null)
            {
                throw new Exception("Уже есть Склад с таким Названием");
            }
            context.Stores.Add(new Store
            {
                StockName = model.StoreName
            });
            context.SaveChanges();
        }
        public void UpdElement(StoreBindingModel model)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.StockName ==
           model.StoreName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = context.Stores.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StockName = model.StoreName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Stores.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}