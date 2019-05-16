using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryServiceDAL.ViewModels
{
    public class StoreLoadViewModel
    {
        public string StoreName { get; set; }
        public int TotalNumber { get; set; }
        public IEnumerable<Tuple<string, int>> Details { get; set; }
    }
}
