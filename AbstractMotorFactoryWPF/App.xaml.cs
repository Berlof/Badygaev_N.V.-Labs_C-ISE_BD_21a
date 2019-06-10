using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceImplementList.Implementations;
using System;
using System.Windows;
using Unity;
using Unity.Lifetime;

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
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEngineService, EngineServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDetailService, DetailServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICoreService, CoreServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStoreService, StoreServiceList>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
