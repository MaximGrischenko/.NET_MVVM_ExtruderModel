using System.Windows.Input;
using Prism.Modularity;
using Prism.Regions;
using Prism.Commands;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Message.ViewModel
{
    public class MessageViewModel: IViewModel
    {
        internal virtual IRegionManager RegionManager { get; set; }
        internal virtual IModuleManager ModuleManager { get; set; }

        public MessageViewModel(IRegionManager regionManager, IModuleManager moduleManager)
        {
            RegionManager = regionManager;
            ModuleManager = moduleManager;

            this.CloseMessages = new DelegateCommand(
                () =>
                {
                    ModuleManager.LoadModule("TempParameters");
                    RegionManager.RequestNavigate("ContentRegion", "TempParametersView");
                });
        }

        public ICommand CloseMessages { get; set; }
    }
}
