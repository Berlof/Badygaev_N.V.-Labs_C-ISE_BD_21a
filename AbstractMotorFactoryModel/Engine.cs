using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryModel
{
    public class Engine
    {
        public int Id { get; set; }

        [Required]
        public string EngineName { get; set; }

        public decimal Cost { get; set; }

        [ForeignKey("EngineId")]
        public virtual List<Production> Productions { get; set; }
    }

}
