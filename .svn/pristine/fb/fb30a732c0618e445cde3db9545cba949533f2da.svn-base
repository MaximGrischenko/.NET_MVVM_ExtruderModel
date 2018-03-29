using System;
using System.Collections.Generic;

namespace SharedCommunicationClassesLibrary
{
    public interface IExtruderControl
    {
        void Start();
        void Stop();
        void SetParameter(List<IPIDControl> parameters);
        void SetDataToLoop(IPIDReference reference);

        event EventHandler LoopDataChanged;

    }
}
