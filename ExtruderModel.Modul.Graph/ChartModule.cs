using ExtruderModel.Module.Graph.View;
using ExtruderModel.Module.Graph.ViewModel;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Graph
{
    public class Chart : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public Chart(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            this._container.RegisterType<IView, ChartView>("Chart");
            this._container.RegisterType<IViewModel, ChartViewModel>("Chart");

            this._regionManager.RegisterViewWithRegion("ContentRegion", () => this._container.Resolve<IView>("Chart"));
        }
    }


}