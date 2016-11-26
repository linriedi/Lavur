using Sync;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class Service
    {
        public Service()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    Debug.WriteLine("Hallo 1");

                    SyncPointConnection.First.Wait();
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    Debug.WriteLine("Hallo 2");

                    SyncPointConnection.Second.Wait();
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    Debug.WriteLine("Hallo 3");

                    SyncPointConnection.Third.Wait();
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    Debug.WriteLine("Hallo 4");

                    SyncPointConnection.Fourth.Wait();
                }
            });
        }
    }
}
