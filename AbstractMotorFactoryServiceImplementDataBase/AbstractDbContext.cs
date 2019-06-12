﻿using AbstractMotorFactoryModel;
using System.Data.Entity;

namespace AbstractMotorFactoryServiceImplementDataBase
{
    public class AbstractDbContext : DbContext
    {
        public AbstractDbContext() : base("AbstractDatabase")
        {
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
