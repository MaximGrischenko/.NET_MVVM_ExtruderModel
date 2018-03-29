using System;
using System.Collections.Generic;
using SharedCommunicationClassesLibrary;
using ExtruderEmulatorLibrarry;

namespace ExtruderControlLibrary
{
    public class ExtruderControl: IExtruderControl
    {
        private readonly IExtruderEmulator _emulator;
        public ExtruderControl(IExtruderEmulator extruderEmulator)
        {
            _emulator = extruderEmulator;
        }
        public void Start()
        {
            this._emulator.Start();
        }

        public void Stop()
        {
            this._emulator.Stop();
        }

        public void SetParameter(List<IPIDControl> parameters)
        {
            this._emulator.SetLoopParameters(new Tuple<List<IPIDControl>, IPIDReference>(parameters, null));
        }

        public void SetDataToLoop(IPIDReference reference)
        {
            this._emulator.SetLoopParameters(new Tuple<List<IPIDControl>, IPIDReference>(null, reference));
        }

        public event EventHandler LoopDataChanged;

    }
}
