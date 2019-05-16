using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryServiceDAL.Interfaces
{
    public interface IReportService
    {
        void SaveEnginePrice(ReportBindingModel model);
        List<StoreLoadViewModel> GetStoresLoad();
        void SaveStoresLoad(ReportBindingModel model);
        List<CustomerOrdersModel> GetCustomerOrders(ReportBindingModel model);
        void SaveCustomerOrders(ReportBindingModel model);
    }
}
