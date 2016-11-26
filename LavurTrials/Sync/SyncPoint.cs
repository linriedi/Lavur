using System;
using System.Threading;

namespace Sync
{
    public class SyncPoint
    {
        public event EventHandler Blocked;
        public event EventHandler Released;

        private readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        public bool IsActivated { get; private set; }

        public SyncPoint()
        {
            this.IsActivated = true;
        }

        public void Wait()
        {
            var handler = this.Blocked;
            if(handler != null)
            {
                handler(this, new EventArgs());
            }

            this.resetEvent.WaitOne();

            handler = this.Released;
            if(handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public void Release()
        {
            this.resetEvent.Set();
            this.IsActivated = false;
        }

        public void Block()
        {
            this.resetEvent.Reset();
            this.IsActivated = true;
        }
    }
}
