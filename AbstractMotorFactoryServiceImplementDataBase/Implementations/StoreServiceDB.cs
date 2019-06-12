using AbstractMotorFactoryModel;
using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<StoreViewModel> result = context.Stores.Select(rec => new StoreViewModel
            {
                Id = rec.Id,
                StoreName = rec.StoreName,
                StoreDetails = context.StoreDetails
                    .Where(recPC => recPC.Id == rec.Id)
                    .Select(recPC => new StoreDetailViewModel
                    {
                        Id = recPC.Id,
                        StoreId = recPC.StoreId,
                        DetailId = recPC.DetailId,
                        DetailName = recPC.Detail.DetailName,
                        Number = recPC.Number
                    })
                   .ToList()
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
                    StoreName = element.StoreName,
                    StoreDetails = context.StoreDetails
                    .Where(recPC => recPC.Id == element.Id)
                    .Select(recPC => new StoreDetailViewModel
                    {
                        Id = recPC.Id,
                        StoreId = recPC.StoreId,
                        DetailId = recPC.DetailId,
                        DetailName = recPC.Detail.DetailName,
                        Number = recPC.Number
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StoreBindingModel model)
        {
            Store element = context.Stores.FirstOrDefault(rec =>
            rec.StoreName == model.StoreName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = new Store
            {
                StoreName = model.StoreName,
            };
            context.Stores.Add(element);
            context.SaveChanges();
        }

        public void UpdElement(StoreBindingModel model)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.StoreName == model.StoreName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = context.Stores.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StoreName = model.StoreName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Store element = context.Stores.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.StoreDetails.RemoveRange(context.StoreDetails.Where(rec =>
                        rec.StoreId == id));
                        context.Stores.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
