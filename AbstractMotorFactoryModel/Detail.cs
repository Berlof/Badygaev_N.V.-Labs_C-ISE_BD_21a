using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryModel
{
    public class Detail
    {
        public int Id { get; set; }

        [Required]
        public string DetailName { get; set; }

        [ForeignKey("DetailId")]
        public virtual List<EngineDetail> EngineDetails { get; set; }

        [ForeignKey("DetailId")]
        public virtual List<StoreDetail> StoreDetails { get; set; }
        public object Price { get; set; }
    }
}
