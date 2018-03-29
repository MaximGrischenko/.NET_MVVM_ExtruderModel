using Microsoft.Practices.Prism.ViewModel;
using SharedCommunicationClassesLibrary;

namespace ExtruderModel.Module.Temperature_Parameters.ViewModel
{
    class TempParametersViewModel : NotificationObject, IViewModel
    {

        private readonly IExtruderControl _extruderControl;
        private readonly IPidActual[] _valuesPidActual;

        public TempParametersViewModel(IExtruderControl extruderControl)
        {
            _valuesPidActual = new IPidActual[7];

            for (int i = 0; i < _valuesPidActual.Length; i++)
            {
                _valuesPidActual[i] = new PIDActual() { Loop = i, FromPidTempReference = 15.0, FromPidTempActual = 10.0 };
            }

            this._extruderControl = extruderControl;
            this._extruderControl.LoopDataChanged += (s, args) =>
            {
                //
            };
        }

        public double Zone1TempReference
        {
            get { return this._valuesPidActual[0].FromPidTempReference; }
            set
            {
                if (value != null)
                    this._extruderControl.SetDataToLoop(new PIDReference()
                    {
                        Loop = 0,
                        ToPidTempReference = value
                    });
                this.RaisePropertyChanged(() => this.Zone1TempReference);
            }
        }
        public double Zone2TempReference
        {
            get { return this._valuesPidActual[1].FromPidTempReference; }
            set
            {
                if (value != null)
                    this._extruderControl.SetDataToLoop(new PIDReference()
                    {
                        Loop = 1,
                        ToPidTempReference = value
                    });
                this.RaisePropertyChanged(() => this.Zone2TempReference);
            }
        }
        public double Zone3TempReference
        {
            get { return this._valuesPidActual[2].FromPidTempReference; }
            set
            {
                if (value != null)
                    this._extruderControl.SetDataToLoop(new PIDReference()
                    {
                        Loop =2,
                        ToPidTempReference = value
                    });
                this.RaisePropertyChanged(() => this.Zone3TempReference);
            }
        }

        public double Zone4TempReference
        {
            get { return this._valuesPidActual[3].FromPidTempReference; }
            set
            {
                if (value != null)
                    this._extruderControl.SetDataToLoop(new PIDReference()
                    {
                        Loop = 3,
                        ToPidTempReference = value
                    });
                this.RaisePropertyChanged(() => this.Zone4TempReference);
            }
        }
        public double Zone5TempReference
        {
            get { return this._valuesPidActual[4].FromPidTempReference; }
            set
            {
                if (value != null)
                    this._extruderControl.SetDataToLoop(new PIDReference()
                    {
                        Loop = 4,
                        ToPidTempReference = value
                    });
                this.RaisePropertyChanged(() => this.Zone5TempReference);
            }
        }
        public double Zone6TempReference
        {
            get { return this._valuesPidActual[5].FromPidTempReference; }
            set
            {
                if (value != null)
                    this._extruderControl.SetDataToLoop(new PIDReference()
                    {
                        Loop = 5,
                        ToPidTempReference = value
                    });
                this.RaisePropertyChanged(() => this.Zone6TempReference);
            }
        }
        public double Zone7TempReference
        {
            get { return this._valuesPidActual[6].FromPidTempReference; }
            set
            {
                if (value != null)
                    this._extruderControl.SetDataToLoop(new PIDReference()
                    {
                        Loop = 6,
                        ToPidTempReference = value
                    });
                this.RaisePropertyChanged(() => this.Zone7TempReference);
            }
        }

        class PIDReference : IPIDReference
        {
            public int Loop { get; set; }
            public double ToPidTempReference { get; set; }
        }
        class PIDActual : IPidActual
        {
            public int Loop { get; set; }
            public double FromPidTempReference { get; set; }
            public double FromPidTempActual { get; set; }
        }
    }
}
