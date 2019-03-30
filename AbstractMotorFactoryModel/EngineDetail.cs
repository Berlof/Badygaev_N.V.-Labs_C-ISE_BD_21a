using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryModel
{
    public class EngineDetail
    {
        public int Id { get; set; }

        public int EngineId { get; set; }

        public int DetailId { get; set; }

        public int Number { get; set; }

        public virtual Detail Detail { get; set; }

        public virtual Engine Engine { get; set; }
    }
}
