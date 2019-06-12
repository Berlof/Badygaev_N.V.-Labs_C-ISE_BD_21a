using System.ComponentModel.DataAnnotations;

namespace AbstractMotorFactoryModel
{
    public class StoreDetail
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int DetailId { get; set; }

        [Required]
        public int Number { get; set; }

        public virtual Store Store { get; set; }

        public virtual Detail Detail { get; set; }
    }
}
