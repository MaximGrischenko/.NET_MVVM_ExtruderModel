using System.Runtime.Remoting.Channels;
using System.Windows.Input;
using ExtruderControlLibrary;
using Microsoft.Practices.Prism.ViewModel;
using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;


using SharedCommunicationClassesLibrary;


namespace ExtruderModel.UI.Main.ViewModel
{

    public class MainViewModel: NotificationObject, IViewModel
    {
        internal virtual IRegionManager RegionManager { get; set; }
        internal virtual IModuleManager ModuleManager { get; set; }

        private readonly IExtruderControl _extruderControl;

        public MainViewModel(IRegionManager regionManager, IModuleManager moduleManager, IExtruderControl extruderControl)
        {
            this._extruderControl = extruderControl;
            this._extruderControl.LoopDataChanged += (s, args) =>
            {
                // тут мы зпаполним массив 
            }; 

            RegionManager = regionManager;
            ModuleManager = moduleManager;

            this.SettingsCommand = new DelegateCommand(
                () =>
                {
                    ModuleManager.LoadModule("PidParameters");
                    RegionManager.RequestNavigate("ContentRegion", "PidParametersView");
                });

            this.GraphCommand = new DelegateCommand(
                () =>
                {
                    ModuleManager.LoadModule("Chart");
                    RegionManager.RequestNavigate("ContentRegion", "ChartView");
                });

            this.MessageCommand = new DelegateCommand(
                () =>
                {
                    ModuleManager.LoadModule("Message");
                    RegionManager.RequestNavigate("ContentRegion", "MessageView");
                });


        }

        public ICommand SettingsCommand { get; set; }
        public ICommand GraphCommand { get; set; }
        public ICommand MessageCommand { get; set; }
    }
}