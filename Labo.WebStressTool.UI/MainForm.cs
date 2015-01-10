namespace Labo.WebStressTool.UI
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;

    using Labo.WebStressTool.Core;

    using Timer = System.Timers.Timer;

    public partial class MainForm : Form
    {
        private IList<HttpRequestRecord> m_HttpRequestRecords;

        private HttpRequestWorkerQueue m_HttpRequestWorkerQueue;

        private bool m_Running;

        public MainForm()
        {
            InitializeComponent();
        }

        private void fiddlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FiddlerForm fiddlerForm = new FiddlerForm())
            {
                fiddlerForm.ShowDialog(this);
                m_HttpRequestRecords = fiddlerForm.Records;
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
                        StopHttpRequestWorkerQueue(true);
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

                    if (addedRequests >= maxQueueLength)
                    {
                        break;
                    }
                }
            }
        }

        private void UpdateRunningRequestCount(int count)
        {
            if (lblRunningRequestsCount.InvokeRequired)
            {
                lblRunningRequestsCount.Invoke(new MethodInvoker(() => lblRunningRequestsCount.Text = count.ToString(CultureInfo.InvariantCulture)));
            }
            else
            {
                lblRunningRequestsCount.Text = count.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void UpdateQueueLength(int count)
        {
            if (lblQueueLength.InvokeRequired)
            {
                lblQueueLength.Invoke(new MethodInvoker(() => lblQueueLength.Text = count.ToString(CultureInfo.InvariantCulture)));
            }
            else
            {
                lblQueueLength.Text = count.ToString(CultureInfo.InvariantCulture);
            }
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
                                item.SubItems.Add(result.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
                                lvRequests.Items.Add(item);
                            };

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
            ThreadPool.QueueUserWorkItem(x => UpdateRunningRequestCount(m_HttpRequestWorkerQueue.RunningWorkersCount));
        }

        private void HttpRequestWorkerQueue_OnHttpRequestWorkerQueueShutDown(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => UpdateRunningRequestCount(m_HttpRequestWorkerQueue.RunningWorkersCount));
        }

        private void HttpRequestWorkerQueue_OnRequestWorkerStarting(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => UpdateRunningRequestCount(m_HttpRequestWorkerQueue.RunningWorkersCount));
        }

        private void HttpRequestWorkerQueue_OnRequestQueueUpdated(object sender, HttpRequestWorkerQueue.RequestQueueUpdatedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => UpdateQueueLength(e.QueueLength));
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
    }
}
