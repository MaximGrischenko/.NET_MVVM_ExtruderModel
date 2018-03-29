using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LoggingClassLibrary;
using SharedCommunicationClassesLibrary;

namespace ExtruderEmulatorLibrarry
{
    public class ExtruderEmulator : IExtruderEmulator
    {
        private readonly ILogLibrary _logLibrary;

        private CancellationTokenSource _cts;
        private CancellationToken _ct;
        private Task[] _tasks;

        readonly BlockingCollection<Tuple<List<IPIDControl>, IPIDReference>> _fifoBlock = new BlockingCollection<Tuple<List<IPIDControl>, IPIDReference>>();

        public ExtruderEmulator(ILogLibrary logLibrary)
        {
            _logLibrary = logLibrary;
        }

        public void Start()
        {
            _cts = new CancellationTokenSource();

            _ct = _cts.Token;


            var t1 = Task.Factory.StartNew(() =>
            {
                var loop = 0;

                while (!_ct.IsCancellationRequested)
                {
                    foreach (var buf in _fifoBlock.GetConsumingEnumerable())
                    {

                    }
                    switch (loop)
                    {
                        case 0:

                            break;

                        default:
                            loop = 0;
                            break;
                    }
                    loop++;

                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }, _ct);

            _tasks = new[] { t1 };

        }

        public void Stop()
        {
            _cts.Cancel();

            try
            {
                Task.WaitAll(_tasks, 2000);
            }
            catch (AggregateException exception)
            {
                foreach (var innerException in exception.InnerExceptions)
                {
                    _logLibrary.Error(innerException, "Ошибка");
                }
            }

        }

        public void SetLoopParameters(Tuple<List<IPIDControl>, IPIDReference> loopTuple)
        {
            _fifoBlock.Add(loopTuple, _ct);
        }
    }
}
