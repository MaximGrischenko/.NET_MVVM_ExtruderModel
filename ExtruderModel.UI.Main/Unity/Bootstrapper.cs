using System.IO;
using System.Windows;
using ExtruderControlLibrary;
using ExtruderEmulatorLibrarry;
using ExtruderModel.Module.Graph;
using ExtruderModel.Module.Temperature_Parameters;
using ExtruderModel.Module.PID_Parameters;
using ExtruderModel.Module.Message;
using ExtruderModel.UI.Main.ViewModel;
using LoggingClassLibrary;
using Microsoft.Practices.Unity;
using Prism.Logging;
using Prism.Modularity;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.UI.Main.Unity
{
      class Bootstrapper: Prism.Unity.UnityBootstrapper
      {
            protected override void InitializeShell()
            {
                  Application.Current.MainWindow = (Window)this.Shell;
                  Application.Current.MainWindow.Show();
            }

            protected override DependencyObject CreateShell()
            {
                  //this.Container.RegisterType<IShellView, Shell>();
                  this.Container.RegisterType<IViewModel, MainViewModel>(new ContainerControlledLifetimeManager());
                  
                  ///** регистрируем логгер */
                  this.Container.RegisterType<ILogLibrary, LogLibrary>(new ContainerControlledLifetimeManager());

                  ///** регистрируем модуль работы с сервисом WCF*/
                  this.Container.RegisterType<IExtruderControl, ExtruderControl>(new ContainerControlledLifetimeManager());

                  ///** регистрируем модуль работы с сервисом WCF*/
                  this.Container.RegisterType<IExtruderEmulator, ExtruderEmulator>(new ContainerControlledLifetimeManager());

                  return Container.Resolve<MainWindow>();
            }

            protected override IModuleCatalog CreateModuleCatalog()
            {
                  var moduleCatalog = new ModuleCatalog();

            //** загружаем модули */
                moduleCatalog.AddModule(typeof(TempParameters));                                /** модуль окна приветствия */
                moduleCatalog.AddModule(typeof(PidParameters), InitializationMode.OnDemand);    /** модуль окна настроек */
                moduleCatalog.AddModule(typeof(Chart), InitializationMode.OnDemand);            /** модуль окна графиков */
                moduleCatalog.AddModule(typeof(Message), InitializationMode.OnDemand);          /** модуль окна сообщений */

            return moduleCatalog;
            }
      }
}
