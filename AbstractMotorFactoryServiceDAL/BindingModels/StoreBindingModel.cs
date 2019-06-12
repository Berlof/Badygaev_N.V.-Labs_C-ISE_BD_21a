using System.Runtime.Serialization;

namespace AbstractMotorFactoryServiceDAL.BindingModels
{
    [DataContract]
    public class StoreBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string StoreName { get; set; }
    }
}
