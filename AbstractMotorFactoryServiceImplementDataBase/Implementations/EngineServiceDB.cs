using AbstractMotorFactoryModel;
using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryServiceImplementDataBase.Implementations
{
    public class EngineServiceDB : IEngineService
    {
        private AbstractDbContext context;
        public EngineServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<EngineViewModel> GetList()
        {
            List<EngineViewModel> result = context.Engines.Select(rec => new  EngineViewModel
            {
                Id = rec.Id,
                EngineName = rec.EngineName,
                Cost = rec.Cost,
                EngineDetails = context.EngineDetails
            .Where(recPC => recPC.EngineId == rec.Id)
           .Select(recPC => new EngineDetailViewModel
           {
               Id = recPC.Id,
               EngineId = recPC.EngineId,
               DetailId = recPC.DetailId,
               DetailName = recPC.Detail.DetailName,
               Number = recPC.Number
           })
           .ToList()
            })
            .ToList();
            return result;
        }
        public EngineViewModel GetElement(int id)
        {
            Engine element = context.Engines.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new EngineViewModel
                {
                    Id = element.Id,
                    EngineName = element.EngineName,
                    Cost = element.Cost,
                    EngineDetails = context.EngineDetails
 .Where(recPC => recPC.EngineId == element.Id)
 .Select(recPC => new EngineDetailViewModel
 {
     Id = recPC.Id,
     EngineId = recPC.EngineId,
     DetailId = recPC.DetailId,
     DetailName = recPC.Detail.DetailName,
     Number = recPC.Number
 })
 .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(EngineBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Engine element = context.Engines.FirstOrDefault(rec =>
                   rec.EngineName == model.EngineName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Engine
                    {
                        EngineName = model.EngineName,
                        Cost = model.Cost
                    };
                    context.Engines.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupDetails = model.EngineDetails
                     .GroupBy(rec => rec.DetailId)
                    .Select(rec => new
                    {
                        DetailId = rec.Key,
                        Number = rec.Sum(r => r.Number)
                    });
                    // добавляем компоненты
                    foreach (var groupDetail in groupDetails)
                    {
                        context.EngineDetails.Add(new EngineDetail
                        {
                            EngineId = element.Id,
                            DetailId = groupDetail.DetailId,
                            Number = groupDetail.Number
                        });
                        context.SaveChanges();
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
        public void UpdElement(EngineBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Engine element = context.Engines.FirstOrDefault(rec =>
                   rec.EngineName == model.EngineName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Engines.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.EngineName = model.EngineName;
                    element.Cost = model.Cost;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.EngineDetails.Select(rec =>
                   rec.DetailId).Distinct();
                    var updateDetails = context.EngineDetails.Where(rec =>
                   rec.EngineId == model.Id && compIds.Contains(rec.DetailId));
                    foreach (var updateDetail in updateDetails)
                    {
                        updateDetail.Number =
                       model.EngineDetails.FirstOrDefault(rec => rec.Id == updateDetail.Id).Number;
                    }
                    context.SaveChanges();
                    context.EngineDetails.RemoveRange(context.EngineDetails.Where(rec =>
                    rec.EngineId == model.Id && !compIds.Contains(rec.DetailId)));
                    context.SaveChanges();
                    // новые записи
                    var groupDetails = model.EngineDetails
                    .Where(rec => rec.Id == 0)
                   .GroupBy(rec => rec.DetailId)
                   .Select(rec => new
                   {
                       DetailId = rec.Key,
                       Number = rec.Sum(r => r.Number)
                   });
                    foreach (var groupDetail in groupDetails)
                    {
                        EngineDetail elementPC =
                       context.EngineDetails.FirstOrDefault(rec => rec.EngineId == model.Id &&
                       rec.DetailId == groupDetail.DetailId);
                        if (elementPC != null)
                        {
                            elementPC.Number += groupDetail.Number;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.EngineDetails.Add(new EngineDetail
                            {
                                EngineId = model.Id,
                                DetailId = groupDetail.DetailId,
                                Number = groupDetail.Number
                            });
                            context.SaveChanges();
                        }
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
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Engine element = context.Engines.FirstOrDefault(rec => rec.Id ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.EngineDetails.RemoveRange(context.EngineDetails.Where(rec =>
                        rec.EngineId == id));
                        context.Engines.Remove(element);
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