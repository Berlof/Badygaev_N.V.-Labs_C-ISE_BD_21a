using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractMotorFactoryServiceDAL.ViewModels
{
    [DataContract]
    public class StoreViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название склада")]
        public string StoreName { get; set; }

        [DataMember]
        [DisplayName("Детали на складе")]
        public List<StoreDetailViewModel> StoreDetails { get; set; }
    }
}
