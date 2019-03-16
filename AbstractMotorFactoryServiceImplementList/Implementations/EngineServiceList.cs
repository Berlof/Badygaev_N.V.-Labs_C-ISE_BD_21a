using AbstractMotorFactoryModel;
using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractMotorFactoryServiceImplementList.Implementations
{
    public class EngineServiceList : IEngineService
    {
        private DataListSingleton source;

        public EngineServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<EngineViewModel> GetList()
        {
            List<EngineViewModel> result = source.Engines
            .Select(rec => new EngineViewModel
            {
                Id = rec.Id,
                EngineName = rec.EngineName,
                Cost = rec.Cost,
                EngineDetails = source.EngineDetails
            .Where(recPC => recPC.EngineId == rec.Id)
           .Select(recPC => new EngineDetailViewModel
           {
               Id = recPC.Id,
               EngineId = recPC.EngineId,
               DetailId = recPC.DetailId,
               DetailName = source.Details.FirstOrDefault(recC =>
    recC.Id == recPC.DetailId)?.DetailName,
               Number = recPC.Number
           })
           .ToList()
            })
            .ToList(); return result;
        }
        public EngineViewModel GetElement(int id)
        {
            Engine element = source.Engines.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new EngineViewModel
                {
                    Id = element.Id,
                    EngineName = element.EngineName,
                    Cost = element.Cost,
                    EngineDetails = source.EngineDetails
                .Where(recPC => recPC.EngineId == element.Id)
                .Select(recPC => new EngineDetailViewModel
                {
                    Id = recPC.Id,
                    EngineId = recPC.EngineId,
                    DetailId = recPC.DetailId,
                    DetailName = source.Details.FirstOrDefault(recC =>
     recC.Id == recPC.DetailId)?.DetailName,
                    Number = recPC.Number
                })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(EngineBindingModel model)
        {
            Engine element = source.Engines.FirstOrDefault(rec => rec.EngineName ==
           model.EngineName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Engines.Count > 0 ? source.Engines.Max(rec => rec.Id) :
           0;
            source.Engines.Add(new Engine
            {
                Id = maxId + 1,
                EngineName = model.EngineName,
                Cost = model.Cost
            });
            // компоненты для изделия
            int maxPCId = source.EngineDetails.Count > 0 ?
           source.EngineDetails.Max(rec => rec.Id) : 0;
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
                source.EngineDetails.Add(new EngineDetail
                {
                    Id = ++maxPCId,
                    EngineId = maxId + 1,
                    DetailId = groupDetail.DetailId,
                    Number = groupDetail.Number
                });
            }
        }
        public void UpdElement(EngineBindingModel model)
        {
            Engine element = source.Engines.FirstOrDefault(rec => rec.EngineName ==
           model.EngineName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Engines.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.EngineName = model.EngineName;
            element.Cost = model.Cost;
            int maxPCId = source.EngineDetails.Count > 0 ?
           source.EngineDetails.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.EngineDetails.Select(rec =>
           rec.DetailId).Distinct();
            var updateDetails = source.EngineDetails.Where(rec => rec.EngineId ==
           model.Id && compIds.Contains(rec.DetailId));
            foreach (var updateDetail in updateDetails)
            {
                updateDetail.Number = model.EngineDetails.FirstOrDefault(rec =>
               rec.Id == updateDetail.Id).Number;
            }
            source.EngineDetails.RemoveAll(rec => rec.EngineId == model.Id &&
           !compIds.Contains(rec.DetailId));
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
                EngineDetail elementPC = source.EngineDetails.FirstOrDefault(rec
               => rec.EngineId == model.Id && rec.DetailId == groupDetail.DetailId);
                if (elementPC != null)
                {
                    elementPC.Number += groupDetail.Number;
                }
                else
                {
                    source.EngineDetails.Add(new EngineDetail
                    {
                        Id = ++maxPCId,
                        EngineId = model.Id,
                        DetailId = groupDetail.DetailId,
                        Number = groupDetail.Number
                    });
                }
            }
        }
        public void DelElement(int id)
        {
            Engine element = source.Engines.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.EngineDetails.RemoveAll(rec => rec.EngineId == id);
                source.Engines.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}