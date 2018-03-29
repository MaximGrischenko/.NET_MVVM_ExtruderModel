using Microsoft.Practices.Unity;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Temperature_Parameters
{
    /// <summary>
    /// Логика взаимодействия для UControl_TempParameters.xaml
    /// </summary>
    public partial class TempParametersView : IView
    {
        public TempParametersView([Dependency("TempParameters")]IViewModel model)
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
