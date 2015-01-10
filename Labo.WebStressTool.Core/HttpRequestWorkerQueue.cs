namespace Labo.WebStressTool.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public sealed class HttpRequestWorkerQueue
    {
        public sealed class RequestQueueUpdatedEventArgs : EventArgs
        {
            private readonly int m_QueueLength;

            public int QueueLength
            {
                get
                {
                    return m_QueueLength;
                }
            }

            public RequestQueueUpdatedEventArgs(int queueLength)
            {
                m_QueueLength = queueLength;
            }
        }

        public event EventHandler OnRequestWorkerStarting = delegate { };

        public event EventHandler OnRequestWorkerCompleted = delegate { };

        public event EventHandler<RequestQueueUpdatedEventArgs> OnRequestQueueUpdated = delegate { };

        public event EventHandler OnHttpRequestWorkerQueueShutDown = delegate { };

        private readonly Queue<HttpRequestWorker> m_HttpRequestWorkersQueue;
        private readonly object m_Locker = new object();
        private readonly Thread[] m_Workers;

        private DateTime? m_StartDate;

        private DateTime? m_EndDate;

        private int m_RunningWorkersCount;

        private int m_TotalRequestsCompleted;

        public int RunningWorkersCount
        {
            get
            {
                return m_RunningWorkersCount;
            }
        }

        public int TotalRequestsCompleted
        {
            get
            {
                return m_TotalRequestsCompleted;
            }
        }

        public DateTime? StartDate
        {
            get
            {
                return m_StartDate;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return m_EndDate;
            }
        }

        public HttpRequestWorkerQueue(int workerCount)
        {
            m_HttpRequestWorkersQueue = new Queue<HttpRequestWorker>();
            m_Workers = new Thread[workerCount];

            for (int i = 0; i < m_Workers.Length; i++)
            {
                m_Workers[i] = new Thread(DoWork);
            }
        }

        public void EnqueueHttpRequestWorker(HttpRequestWorker httpRequestWorker)
        {
            lock (m_Locker)
            {
                m_HttpRequestWorkersQueue.Enqueue(httpRequestWorker);

                OnRequestQueueUpdated(this, new RequestQueueUpdatedEventArgs(QueueLength));

                Monitor.Pulse(m_Locker);
            }
        }

        public int QueueLength
        {
            get
            {
                lock (m_Locker)
                {
                    return m_HttpRequestWorkersQueue.Count(x => x != null);
                }
            }
        }

        public void Start()
        {
            m_StartDate = DateTime.Now;

            for (int i = 0; i < m_Workers.Length; i++)
            {
                Thread worker = m_Workers[i];
                worker.Start();
            }
        }

        public void Shutdown(bool waitForHttpRequestWorkers)
        {
            for (int i = 0; i < m_Workers.Length; i++)
            {
                EnqueueHttpRequestWorker(null);
            }

            if (waitForHttpRequestWorkers)
            {
                for (int i = 0; i < m_Workers.Length; i++)
                {
                    Thread worker = m_Workers[i];
                    if (worker != null)
                    {
                        worker.Join();
                    }
                }
            }

            for (int i = 0; i < m_Workers.Length; i++)
            {
                Thread worker = m_Workers[i];
                if (worker != null)
                {
                    worker.Abort();
                }

                m_Workers[i] = null;
            }

            lock (m_Locker)
            {
                m_HttpRequestWorkersQueue.Clear();
            }

            m_EndDate = DateTime.Now;

            OnHttpRequestWorkerQueueShutDown(this, EventArgs.Empty);
        }

        private void DoWork()
        {
            while (true)
            {
                HttpRequestWorker httpRequestWorker;
                lock (m_Locker)
                {
                    while (m_HttpRequestWorkersQueue.Count == 0)
                    {
                        Monitor.Wait(m_Locker);
                    }

                    httpRequestWorker = m_HttpRequestWorkersQueue.Dequeue();

                    OnRequestQueueUpdated(this, new RequestQueueUpdatedEventArgs(QueueLength));
                }

                if (httpRequestWorker == null)
                {
                    return;
                }

                try
                {
                    OnRequestWorkerStarting(this, EventArgs.Empty);

                    Interlocked.Increment(ref m_RunningWorkersCount);

                    httpRequestWorker.Run();
                }
                finally 
                {
                    Interlocked.Decrement(ref m_RunningWorkersCount);

                    Interlocked.Increment(ref m_TotalRequestsCompleted);

                    OnRequestWorkerCompleted(this, EventArgs.Empty);
                }
            }
        }
    }
}
