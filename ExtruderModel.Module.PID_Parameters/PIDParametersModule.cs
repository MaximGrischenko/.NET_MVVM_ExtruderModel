using ExtruderModel.Module.PID_Parameters.ViewModel;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.PID_Parameters
{
    public class PidParameters : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public PidParameters(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            this._container.RegisterType<IView, PidParametersView>("PidParameters");
            this._container.RegisterType<IViewModel, PidParametersViewModel>("PidParameters");

            this._regionManager.RegisterViewWithRegion("ContentRegion", () => this._container.Resolve<IView>("PidParameters"));
        }
    }


}