using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractMotorFactoryServiceDAL.ViewModels
{
    [DataContract]
    public class StoreDetailViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int StoreId { get; set; }

        [DataMember]
        public int DetailId { get; set; }

        [DataMember]
        [DisplayName("Название детали")]
        public string DetailName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Number { get; set; }
    }
}
