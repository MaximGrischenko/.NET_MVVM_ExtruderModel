using System;
using System.Collections.Generic;
using SharedCommunicationClassesLibrary;

namespace ExtruderEmulatorLibrarry
{
    public interface IExtruderEmulator
    {
        void Start();

        void Stop();

        void SetLoopParameters(Tuple<List<IPIDControl>, IPIDReference> loopTuple);

    }
}
