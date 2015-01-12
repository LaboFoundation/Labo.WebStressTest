namespace Labo.WebStressTool.UI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    using Labo.WebStressTool.Core;
    using Labo.WebStressTool.Core.Performance;

    using Timer = System.Timers.Timer;

    public partial class MainForm : Form
    {
        private IList<HttpRequestRecord> m_HttpRequestRecords;

        private HttpRequestWorkerQueue m_HttpRequestWorkerQueue;

        private bool m_Running;

        private int m_SuccessfulRequestCount;

        private readonly PerformanceCounterManager m_PerformanceCounterManager;

        public MainForm()
        {
            InitializeComponent();

            Disposed += MainForm_Disposed;

            m_PerformanceCounterManager = new PerformanceCounterManager();
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            if (m_PerformanceCounterManager != null)
            {
                m_PerformanceCounterManager.Dispose();
            }
        }

        private void fiddlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FiddlerForm fiddlerForm = new FiddlerForm())
            {
                fiddlerForm.ShowDialog(this);
                m_HttpRequestRecords = fiddlerForm.Records;
            }
        }

        private void performanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form form = new PerformanceMonitorForm(m_PerformanceCounterManager))
            {
                form.ShowDialog(this);
            }
        }

        private void btnStartStressTest_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => StartStressTest());
        }

        private void StartStressTest()
        {
            if (m_HttpRequestRecords != null)
            {
                int maxConcurrenRequests;
                int.TryParse(mtxtMaxConcurrentRequests.Text, out maxConcurrenRequests);

                int minSleepTime;
                int.TryParse(mtxtSleepMin.Text, out minSleepTime);

                int maxSleepTime;
                int.TryParse(mtxtSleepMax.Text, out maxSleepTime);

                Random random = new Random();

                List<HttpRequestWorker> httpRequestWorkers = CreateHttpRequestWorkers(maxSleepTime, random, minSleepTime);

                m_Running = true;

                StartHttpRequestWorkerQueue(maxConcurrenRequests);

                Timer timer = new Timer(TimeSpan.FromMinutes(Convert.ToInt32(nudDurationInMinutes.Value)).TotalMilliseconds)
                                  {
                                      AutoReset = false
                                  };
                timer.Elapsed += (o, args) =>
                    {
                        m_Running = false;

                        //TODO: Set status as shutting down
                        StopHttpRequestWorkerQueue(false);
                    };
                timer.Start();

                const int maxQueueLength = 10000;

                int addedRequests = 0;

                while (true)
                {
                    if (!m_Running)
                    {
                        break;
                    }

                    for (int i = 0; i < httpRequestWorkers.Count; i++)
                    {
                        if (addedRequests >= maxQueueLength)
                        {
                            break;
                        }

                        HttpRequestWorker httpRequestWorker = httpRequestWorkers[i];
                        m_HttpRequestWorkerQueue.EnqueueHttpRequestWorker(httpRequestWorker);

                        addedRequests++;
                    }
                }
            }
        }

        private static void UpdateCountLabel(Label label, int count)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new MethodInvoker(() => label.Text = count.ToString(CultureInfo.InvariantCulture)));
            }
            else
            {
                label.Text = count.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void UpdateQueueLength(int count)
        {
            UpdateCountLabel(lblQueueLength, count);
        }

        private List<HttpRequestWorker> CreateHttpRequestWorkers(int maxSleepTime, Random random, int minSleepTime)
        {
            List<HttpRequestWorker> httpRequestWorkers = new List<HttpRequestWorker>(m_HttpRequestRecords.Count);
            for (int i = 0; i < m_HttpRequestRecords.Count; i++)
            {
                HttpRequestRecord httpRequestRecord = m_HttpRequestRecords[i];

                HttpRequestWorker httpRequestWorker = new HttpRequestWorker(
                    httpRequestRecord,
                    maxSleepTime == 0 ? random.Next(0, minSleepTime) : random.Next(minSleepTime, maxSleepTime),
                    50);
                httpRequestWorker.HttpRequestProcessed += (worker, result) =>
                    {
                        MethodInvoker addListViewItem = () =>
                            {
                                ListViewItem item = new ListViewItem(result.HttpRequestRecord.Uri.ToString());
                                item.SubItems.Add(result.Success ? "Success" : "Fail");
                                item.SubItems.Add(GetHttpStatusText(result.HttpResponseStatusCode));
                                item.SubItems.Add(result.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
                                lvRequests.Items.Add(item);
                            };

                        if (result.Success)
                        {
                            Interlocked.Increment(ref m_SuccessfulRequestCount);
                        }

                        if (lvRequests.InvokeRequired)
                        {
                            lvRequests.Invoke(new MethodInvoker(addListViewItem));
                        }
                        else
                        {
                            addListViewItem();
                        }
                    };

                httpRequestWorkers.Add(httpRequestWorker);
            }

            return httpRequestWorkers;
        }

        private static string GetHttpStatusText(HttpStatusCode? httpResponseStatusCode)
        {
            return httpResponseStatusCode.HasValue ? 
                string.Format(CultureInfo.CurrentCulture, "{1} ({0})", httpResponseStatusCode, (int)httpResponseStatusCode) 
                : string.Empty;
        }

        private void StopHttpRequestWorkerQueue(bool waitForHttpRequestWorkers)
        {
            if (m_HttpRequestWorkerQueue != null)
            {
                m_HttpRequestWorkerQueue.Shutdown(waitForHttpRequestWorkers);
            }
        }

        private void StartHttpRequestWorkerQueue(int maxConcurrenRequests)
        {
            m_HttpRequestWorkerQueue = new HttpRequestWorkerQueue(maxConcurrenRequests);
            m_HttpRequestWorkerQueue.OnRequestQueueUpdated += HttpRequestWorkerQueue_OnRequestQueueUpdated;
            m_HttpRequestWorkerQueue.OnRequestWorkerStarting += HttpRequestWorkerQueue_OnRequestWorkerStarting;
            m_HttpRequestWorkerQueue.OnRequestWorkerCompleted += HttpRequestWorkerQueue_OnRequestWorkerCompleted;
            m_HttpRequestWorkerQueue.OnHttpRequestWorkerQueueShutDown += HttpRequestWorkerQueue_OnHttpRequestWorkerQueueShutDown;
            m_HttpRequestWorkerQueue.Start();
        }

        private void HttpRequestWorkerQueue_OnRequestWorkerCompleted(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => UpdateStatistics());
        }

        private void HttpRequestWorkerQueue_OnHttpRequestWorkerQueueShutDown(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => UpdateStatistics());
        }

        private void HttpRequestWorkerQueue_OnRequestWorkerStarting(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => UpdateStatistics());
        }

        private void HttpRequestWorkerQueue_OnRequestQueueUpdated(object sender, HttpRequestWorkerQueue.RequestQueueUpdatedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => UpdateQueueLength(e.QueueLength));
        }

        private void UpdateStatistics()
        {
            UpdateCountLabel(lblRunningRequestsCount, m_HttpRequestWorkerQueue.RunningWorkersCount);
            UpdateCountLabel(lblTotalRequestsCount, m_HttpRequestWorkerQueue.TotalRequestsCompleted);
            UpdateCountLabel(lblSuccessfulRequestsCount, m_SuccessfulRequestCount);
        }

        private void btnStopStressTest_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(
                x =>
                    {
                        m_Running = false;
                        StopHttpRequestWorkerQueue(false);
                    });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopHttpRequestWorkerQueue(false);
        }

        private void timerPerformanceInfo_Tick(object sender, EventArgs e)
        {
            PerformanceInfo currentInformation = m_PerformanceCounterManager.GetCurrentInformation();

            toolStripStatusAvailableMemory.Text = string.Format(CultureInfo.CurrentCulture, "{0:N0} / {1:N0} Mb Memory Available", currentInformation.FreeMemory, currentInformation.TotalMemory);

            int cpuUsage = currentInformation.CpuUsage;
            toolStripStatusCpu.Text = string.Format(CultureInfo.CurrentCulture, "CPU usage {0}%", cpuUsage);

            toolStripStatusCpu.Image = cpuImageList.Images[cpuUsage / 10];
        }
    }
}
