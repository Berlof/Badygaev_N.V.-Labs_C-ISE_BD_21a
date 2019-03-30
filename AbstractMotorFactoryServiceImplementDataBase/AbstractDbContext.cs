using AbstractMotorFactoryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMotorFactoryServiceImplementDataBase
{
    public class AbstractDbContext : DbContext
    {
        public AbstractDbContext() : base("AbstractDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Production> Productions { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<EngineDetail> EngineDetails { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreDetail> StoreDetails { get; set; }
    }
}
