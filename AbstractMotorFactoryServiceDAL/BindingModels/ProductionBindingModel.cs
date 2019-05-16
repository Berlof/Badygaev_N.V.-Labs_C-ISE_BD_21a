using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace AbstractMotorFactoryServiceDAL.BindingModels
{
    [DataContract]
    public class ProductionBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int EngineId { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
    }
}
