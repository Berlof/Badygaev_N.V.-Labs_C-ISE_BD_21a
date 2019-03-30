using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryModel
{
    /// <summary>
    /// Хранилиище компонентов в магазине
    /// </summary>
    public class Store
    {
        public int Id { get; set; }
        
        [Required]
        public string StockName { get; set; }

        [ForeignKey("StoreId")]
        public virtual List<StoreDetail> StoreDetails { get; set; }
    }
}