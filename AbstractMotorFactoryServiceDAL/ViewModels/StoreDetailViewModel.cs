using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryServiceDAL.ViewModels
{
    public class StoreDetailViewModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int DetailId { get; set; }
        [DisplayName("Название компонента")]
        public string DetailName { get; set; }
        [DisplayName("Количество")]
        public int Number { get; set; }
    }

}
