using System;
using System.Windows.Forms;

namespace Labo.WebStressTool.UI
{
    using System.Globalization;

    using Labo.WebStressTool.Core.Performance;

    public partial class PerformanceMonitorForm : Form
    {
        private readonly PerformanceCounterManager m_PerformanceCounterManager;

        public PerformanceMonitorForm(PerformanceCounterManager performanceCounterManager)
        {
            InitializeComponent();

            m_PerformanceCounterManager = performanceCounterManager;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PerformanceInfo performanceInfo = m_PerformanceCounterManager.GetCurrentInformation();
            NetworkingPerformanceInfo networkingPerformanceInfo = performanceInfo.NetworkingPerformanceInfo;

            lblBytesRecieved.Text = networkingPerformanceInfo.BytesRecieved.ToString("N0", CultureInfo.InvariantCulture);
            lblBytesSent.Text = networkingPerformanceInfo.BytesSent.ToString("N0", CultureInfo.InvariantCulture);
            lblConnectionsEstablished.Text = networkingPerformanceInfo.ConnectionsEstablised.ToString(CultureInfo.InvariantCulture);
            lblCpu.Text = string.Format(CultureInfo.InvariantCulture, "%{0}", performanceInfo.CpuUsage);
            lblFreeMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:N0} / {1:N0} mb", performanceInfo.FreeMemory, performanceInfo.TotalMemory);
        }
    }
}
