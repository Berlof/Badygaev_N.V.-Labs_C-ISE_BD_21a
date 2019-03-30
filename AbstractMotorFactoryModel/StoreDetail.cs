using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryModel
{
    public class StoreDetail
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int DetailId { get; set; }
        public int Number { get; set; }
        public virtual Store Store { get; set; }
        public virtual Engine Engine { get; set; }
    }
}
