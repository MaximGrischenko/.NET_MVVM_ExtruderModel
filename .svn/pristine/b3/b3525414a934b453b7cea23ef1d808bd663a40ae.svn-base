using System.Windows.Input;
using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Graph.ViewModel
{
    public class ChartViewModel: IViewModel
    {
        internal virtual IRegionManager RegionManager { get; set; }
        internal virtual IModuleManager ModuleManager { get; set; }

        public ChartViewModel(IRegionManager regionManager, IModuleManager moduleManager)
        {
            RegionManager = regionManager;
            ModuleManager = moduleManager;

            this.CloseCharts = new DelegateCommand(
                () =>
                {
                    ModuleManager.LoadModule("TempParameters");
                    RegionManager.RequestNavigate("ContentRegion", "TempParametersView");
                });

        }

        public ICommand CloseCharts { get; set; }
    }
}
