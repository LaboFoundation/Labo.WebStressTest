namespace Labo.WebStressTool.Core.Performance
{
    public struct PerformanceInfo
    {
        public int CpuUsage { get; set; }

        public float FreeMemory { get; set; }

        public NetworkingPerformanceInfo NetworkingPerformanceInfo { get; set; }

        public ulong TotalMemory { get; set; }
    }
}