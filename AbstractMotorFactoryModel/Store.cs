using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractMotorFactoryModel
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        public string StoreName { get; set; }

        [ForeignKey("StoreId")]
        public virtual List<StoreDetail> StoreDetails { get; set; }
    }
}