using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace AbstractMotorFactoryServiceDAL.BindingModels
{
    [DataContract]
    public class StoreDetailBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StoreId { get; set; }
        [DataMember]
        public int DetailId { get; set; }
        [DataMember]
        public int Number { get; set; }
    }
}
