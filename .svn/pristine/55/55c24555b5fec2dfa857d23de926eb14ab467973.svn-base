using ExtruderModel.Module.Temperature_Parameters.ViewModel;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Temperature_Parameters
{
    public class TempParameters : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public TempParameters(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            this._container.RegisterType<IView, TempParametersView>("TempParameters");
            this._container.RegisterType<IViewModel, TempParametersViewModel>("TempParameters");

            this._regionManager.RegisterViewWithRegion("ContentRegion", () => this._container.Resolve<IView>("TempParameters"));
        }
    }


}