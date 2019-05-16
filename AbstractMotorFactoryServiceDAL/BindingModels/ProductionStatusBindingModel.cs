using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace AbstractMotorFactoryServiceDAL.BindingModels
{
    [DataContract]
    public enum ProductionStatusBindingModel
    {
        Принят = 0,

        Выполняется = 1,

        Готов = 2,

        Оплачен = 3
    }
}
