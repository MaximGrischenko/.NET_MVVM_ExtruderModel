using SharedCommunicationClassesLibrary;
using Microsoft.Practices.Unity;

namespace ExtruderModel.Module.PID_Parameters
{
    /// <summary>
    /// Логика взаимодействия для PIDParametersView.xaml
    /// </summary>
    public partial class PidParametersView : IView
    {
        public PidParametersView([Dependency("PidParameters")]IViewModel model)
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
