using Microsoft.Practices.Unity;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Message.View
{
    public partial class MessageView : IView
    {
        public MessageView([Dependency("Message")]IViewModel model)
        {
            InitializeComponent();
            this.ViewModel = model;
        }
        public IViewModel ViewModel
        {
            get { return (IViewModel) DataContext; }

            set
            { DataContext = value; }
        }
    }
}
