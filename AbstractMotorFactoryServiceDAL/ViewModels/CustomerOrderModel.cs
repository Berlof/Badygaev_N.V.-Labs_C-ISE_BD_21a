using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryServiceDAL.ViewModels
{
    public class CustomerOrdersModel
    {
        public string CustomerName { get; set; }
        public string TimeCreate { get; set; }
        public string EngineName { get; set; }
        public int Number { get; set; }
        public decimal Cost { get; set; }
        public string State { get; set; }
    }
}