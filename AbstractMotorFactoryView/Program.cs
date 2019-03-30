using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceImplementDataBase;
using AbstractMotorFactoryServiceImplementDataBase.Implementations;
using AbstractMotorFactoryServiceImplementList.Implementations;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AbstractMotorFactoryView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractDbContext>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDetailService, DetailServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEngineService, EngineServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStoreService, StoreServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICoreService, CoreServiceDB>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
