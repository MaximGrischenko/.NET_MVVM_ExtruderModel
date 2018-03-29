using Microsoft.Practices.Unity;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Graph.View
{
    public partial class ChartView : IView
    {
        public ChartView([Dependency("Chart")]IViewModel model)
        {
            InitializeComponent();
            this.ViewModel = model;
        }
        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
