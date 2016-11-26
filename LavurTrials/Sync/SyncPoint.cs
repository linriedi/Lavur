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

        public int Count { get; private set; }

        public SyncPoint()
        {
            this.IsActivated = true;
        }

        public void Wait()
        {
            this.Count++;
            this.Blocked?.Invoke(this, new EventArgs());

            this.resetEvent.WaitOne();

            this.Released?.Invoke(this, new EventArgs());
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
