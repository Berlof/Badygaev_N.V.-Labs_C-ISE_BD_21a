﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractMotorFactoryServiceDAL.BindingModels
{
    [DataContract]
    public class EngineBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string EngineName { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public List<EngineDetailBindingModel> EngineDetails { get; set; }
    }
}
