using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExtruderModel.Module.PID_Parameters.Annotations;
using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;

using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.PID_Parameters.ViewModel
{
    public class PidParametersViewModel : IViewModel, INotifyPropertyChanged
    {
        protected IExtruderControl ExtruderControl;
        internal virtual IRegionManager RegionManager { get; set; }
        internal virtual IModuleManager ModuleManager { get; set; }

        #region

        readonly List<IPIDControl> _listPidControls = new List<IPIDControl>();

        #endregion

        public PidParametersViewModel(IRegionManager regionManager, IModuleManager moduleManager, IExtruderControl extruderControl)
        {

            this._listPidControls.Add(new PidControl());
            this._listPidControls.Add(new PidControl());
            this._listPidControls.Add(new PidControl());
            this._listPidControls.Add(new PidControl());
            this._listPidControls.Add(new PidControl());
            this._listPidControls.Add(new PidControl());
            this._listPidControls.Add(new PidControl());


            RegionManager = regionManager;
            ModuleManager = moduleManager;
            ExtruderControl = extruderControl;

            this.CloseParameters = new DelegateCommand(
                () =>
                {
                    ModuleManager.LoadModule("TempParameters");
                    RegionManager.RequestNavigate("ContentRegion", "TempParametersView");
                });

            this.SendParameters = new DelegateCommand(
                () =>
                {
                    this.ExtruderControl.SetParameter(_listPidControls);
                });
        }
        #region Property commands
        public ICommand CloseParameters { get; set; }
        public ICommand SendParameters { get; set; }
        #endregion

        #region Публичные свойства
        public IPIDControl Zone1PidControl => this._listPidControls[0];
        public IPIDControl Zone2PidControl => this._listPidControls[1];
        public IPIDControl Zone3PidControl => this._listPidControls[2];
        public IPIDControl Zone4PidControl => this._listPidControls[3];
        public IPIDControl Zone5PidControl => this._listPidControls[4];
        public IPIDControl Zone6PidControl => this._listPidControls[5];
        public IPIDControl Zone7PidControl => this._listPidControls[6];

        #endregion

        #region реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }


    public sealed class PidControl : IPIDControl, INotifyPropertyChanged
    {
        private int _loop = 0;
        private double _k = 0.0;
        private double _ti = 0.0;
        private double _td = 0.0;
        private double _stTemp = 0.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public double StTemp
        {
            get { return _stTemp; }
            set
            {
                _stTemp = value;
                OnPropertyChanged(nameof(StTemp));
            }
        }

        public double Td
        {
            get { return _td; }
            set
            {
                _td = value;
                OnPropertyChanged(nameof(Td));
            }
        }

        public double Ti
        {
            get { return _ti; }
            set
            {
                _ti = value;
                OnPropertyChanged(nameof(Ti));
            }
        }

        public double K
        {
            get { return _k; }
            set
            {
                _k = value;
                OnPropertyChanged(nameof(K));
            }
        }

        public int Loop
        {
            get { return _loop; }
            set
            {
                _loop = value;
                OnPropertyChanged(nameof(Loop));
            }
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
