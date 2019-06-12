using AbstractMotorFactoryModel;
using System.Collections.Generic;

namespace AbstractMotorFactoryServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Detail> Details { get; set; }

        public List<Production> Productions { get; set; }

        public List<Engine> Engines { get; set; }

        public List<EngineDetail> EngineDetails { get; set; }

        public List<Store> Stores { get; set; }

        public List<StoreDetail> StoreDetails { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();

            Details = new List<Detail>();

            Productions = new List<Production>();

            Engines = new List<Engine>();

            EngineDetails = new List<EngineDetail>();

            Stores = new List<Store>();

            StoreDetails = new List<StoreDetail>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }

    }
}
