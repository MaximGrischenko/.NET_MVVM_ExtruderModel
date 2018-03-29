using System;
using System.Windows;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.UI.Main
{
      /// <summary>
      /// Логика взаимодействия для MainWindow.xaml
      /// </summary>
      public partial class MainWindow : IView
    {
        public MainWindow(IViewModel model)
        {
            InitializeComponent();
            this.ViewModel = model;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel) this.DataContext; }

            set{ this.DataContext = value; }
        }
    }
}
