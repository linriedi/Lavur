using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class Service
    {
        public event EventHandler FirstSignaled;

        public Service()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    Debug.WriteLine("Hallo 1");

                    Sync.SyncPointConnection.First.Wait();

                    var handler = this.FirstSignaled;
                    if(handler != null)
                    {
                        handler(this, new EventArgs());
                    }
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Debug.WriteLine("Hallo 2");
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(5000);
                    Debug.WriteLine("Hallo 3");
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(3658);
                    Debug.WriteLine("Hallo 4");
                }
            });
        }
    }
}
