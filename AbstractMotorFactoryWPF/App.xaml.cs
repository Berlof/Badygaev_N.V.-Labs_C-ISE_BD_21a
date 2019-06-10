using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceImplementList.Implementations;
using System;
using System.Windows;
using Unity;
using Unity.Lifetime;
using AbstractMotorFactoryServiceImplementDataBase;
using AbstractMotorFactoryServiceImplementDataBase.Implementations;
using System.Data.Entity;

namespace AbstractMotorFactoryWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            var container = BuildUnityContainer();
            app.Run(container.Resolve<MainWindow>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEngineService, EngineServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDetailService, DetailServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICoreService, CoreServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStoreService, StoreServiceDB>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
