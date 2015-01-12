namespace Labo.WebStressTool.Core.Performance
{
    using System;
    using System.Diagnostics;

    using System.Runtime.Versioning;
    using System.Text;

    using Microsoft.VisualBasic.Devices;

    public sealed class PerformanceCounterManager : IDisposable
    {
        private const int INSTANCE_NAME_MAX_LENGTH = 127;

        // Performance Counter to measure CPU usage
        private readonly PerformanceCounter m_CpuCounter;

        // Performance Counter to measure free memory
        private readonly PerformanceCounter m_FreeMemoryCounter;

        // Performance Counter to measure total bytes recieved by Clr Networking
        private readonly PerformanceCounter m_NetworkingBytesRecievedCounter;

        // Performance Counter to measure total bytes sent by Clr Networking
        private readonly PerformanceCounter m_NetworkingBytesSentCounter;

        // Performance Counter to measure total connections established by Clr Networking
        private readonly PerformanceCounter m_NetworkingConnectionsEstablishedCounter;

        private readonly ComputerInfo m_ComputerInfo;

        private bool m_Disposed;

        public PerformanceCounterManager()
        {
            m_ComputerInfo = new ComputerInfo();
            m_CpuCounter = new PerformanceCounter();

            m_CpuCounter.CategoryName = "Processor";
            m_CpuCounter.CounterName = "% Processor Time";
            m_CpuCounter.InstanceName = "_Total";

            m_FreeMemoryCounter = new PerformanceCounter("Memory", "Available MBytes");

            const string clrNetworkingPerformanceCounterCategoryName = ".NET CLR Networking 4.0.0.0";
            PerformanceCounterCategory clrNetworkingPerformanceCounterCategory = new PerformanceCounterCategory(clrNetworkingPerformanceCounterCategoryName);
            string instanceName = GetInstanceName();

            m_NetworkingConnectionsEstablishedCounter = new PerformanceCounter
                                                            {
                                                                CategoryName = clrNetworkingPerformanceCounterCategoryName,
                                                                CounterName = "Connections Established",
                                                                InstanceName = instanceName,
                                                                InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
                                                                ReadOnly = false,
                                                                RawValue = 0L
                                                            };
            m_NetworkingBytesSentCounter = new PerformanceCounter
                                               {
                                                   CategoryName = clrNetworkingPerformanceCounterCategoryName,
                                                   CounterName = "Bytes Sent",
                                                   InstanceName = instanceName,
                                                   InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
                                                   ReadOnly = false,
                                                   RawValue = 0L
                                               };
            m_NetworkingBytesRecievedCounter = new PerformanceCounter
                                               {
                                                   CategoryName = clrNetworkingPerformanceCounterCategoryName,
                                                   CounterName = "Bytes Received",
                                                   InstanceName = instanceName,
                                                   InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
                                                   ReadOnly = false,
                                                   RawValue = 0L
                                               };

            if (!clrNetworkingPerformanceCounterCategory.InstanceExists(instanceName))
            {
                // We are doing that to add current instance to the clr networking performance counter category
                m_NetworkingConnectionsEstablishedCounter.Increment();
                m_NetworkingConnectionsEstablishedCounter.Decrement();   
            }

            // HttpWebRequest Average Lifetime
            // The average time to completion for all HttpWebRequest objects that ended in the last interval within the AppDomain since the process started. 

            //HttpWebRequest Average Queue Time
            // The average time-on-queue for all HttpWebRequest objects that left the queue in the last interval within the AppDomain since the process started. 

            //HttpWebRequests Created/sec
            // The number of HttpWebRequest objects created per second within the AppDomain. 

            //HttpWebRequests Queued/sec
            // The number of HttpWebRequest objects that were added to the queue per second within the AppDomain. 

            //HttpWebRequests Aborted/sec
            // The number of HttpWebRequest objects where the application called the Abort method per second within the AppDomain. 

            //HttpWebRequests Failed/sec
            // The number of HttpWebRequest objects that received a failed status code from the server per second within the AppDomain. 
        }

        public PerformanceInfo GetCurrentInformation()
        {
            return new PerformanceInfo
                       {
                           TotalMemory = m_ComputerInfo.TotalPhysicalMemory >> 20,
                           FreeMemory = m_FreeMemoryCounter.NextValue(),
                           CpuUsage = (int)m_CpuCounter.NextValue(),
                           NetworkingPerformanceInfo = new NetworkingPerformanceInfo
                                                           {
                                                               BytesRecieved = m_NetworkingBytesRecievedCounter.NextValue(),
                                                               BytesSent = m_NetworkingBytesSentCounter.NextValue(),
                                                               ConnectionsEstablised = m_NetworkingConnectionsEstablishedCounter.NextValue()
                                                           }
                       };
        }

        private static string ReplaceInvalidChars(string instanceName)
        {
            // map invalid characters as suggested by MSDN (see PerformanceCounter.InstanceName Property help)

            StringBuilder result = new StringBuilder(instanceName);
            for (int i = 0; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case '(':
                        result[i] = '[';
                        break;
                    case ')':
                        result[i] = ']';
                        break;
                    case '/':
                    case '\\':
                    case '#':
                        result[i] = '_';
                        break;
                }
            }

            return result.ToString();
        }

        private static string GetInstanceName()
        {
            string friendlyName = ReplaceInvalidChars(AppDomain.CurrentDomain.FriendlyName);
            string postfix = VersioningHelper.MakeVersionSafeName(string.Empty, ResourceScope.Machine, ResourceScope.AppDomain);

            string result = friendlyName + postfix;

            if (result.Length > INSTANCE_NAME_MAX_LENGTH)
            {
                result = friendlyName.Substring(0, INSTANCE_NAME_MAX_LENGTH - postfix.Length) + postfix;
            }

            return result;
        }

        ~PerformanceCounterManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (m_Disposed)
            {
                return;
            }

            if (dispose)
            {
                m_CpuCounter.Dispose();
                m_FreeMemoryCounter.Dispose();
                m_NetworkingBytesRecievedCounter.Dispose();
                m_NetworkingBytesSentCounter.Dispose();
                m_NetworkingConnectionsEstablishedCounter.Dispose();

                m_Disposed = true;
            }
        }
    }
}
