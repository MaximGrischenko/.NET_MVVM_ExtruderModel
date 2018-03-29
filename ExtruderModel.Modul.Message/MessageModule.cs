using ExtruderModel.Module.Message.ViewModel;
using ExtruderModel.Module.Message.View;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Message
{
    public class Message: IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public Message(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            this._container.RegisterType<IView, MessageView>("Message");
            this._container.RegisterType<IViewModel, MessageViewModel>("Message");

            this._regionManager.RegisterViewWithRegion("ContentRegion", () => this._container.Resolve<IView>("Message"));
        }
    }
}
