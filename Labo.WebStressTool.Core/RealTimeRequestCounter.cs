using System.Threading;

namespace Labo.WebStressTool.Core
{
    public static class RealTimeRequestCounter
    {
        private static int s_RequestCount;

        public static int RequestCount
        {
            get { return s_RequestCount; }
        }

        public static void Increment()
        {
            Interlocked.Increment(ref s_RequestCount);
        }

        public static void Decrement()
        {
            Interlocked.Decrement(ref s_RequestCount);
        }
    }
}
