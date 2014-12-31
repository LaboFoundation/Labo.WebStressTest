namespace Labo.WebStressTool.Core
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;

    public delegate void HttpRequestProcessed(HttpRequestWorker httpRequestWorker, HttpRequestProcessedResult result);

    public sealed class HttpRequestWorker
    {
        private readonly HttpRequestRecord m_Record;
        private readonly HttpRequestRecordProcessor m_HttpRequestRecordProcessor;

        private readonly int m_FirstRunDelay;
        private bool m_Running;

        public double AverageMilliSeconds
        {
            get
            {
                if (TotalCount > 0)
                {
                    return TotalMilliSeconds / TotalCount;
                }

                return 0;
            }
        }

        public double TotalMilliSeconds { get; private set; }

        public int FailCount { get; private set; }

        public int SucceessCount { get; private set; }

        public int TotalCount { get; private set; }

        public bool IsRunning { get; private set; }

        public int SleepTime { get; private set; }

        public WebExceptionStatus? LastExceptionStatus { get; private set; }

        public event HttpRequestProcessed HttpRequestProcessed = delegate { };

        public HttpRequestWorker(HttpRequestRecord record)
            : this(record, 10)
        {
        }

        public HttpRequestWorker(HttpRequestRecord record, int sleepTime)
            : this(record, sleepTime, 0)
        {
        }

        public HttpRequestWorker(HttpRequestRecord record, int sleepTime, int firstRunDelay)
        {
            m_Record = record;
            m_FirstRunDelay = firstRunDelay;
            m_HttpRequestRecordProcessor = new HttpRequestRecordProcessor();

            SucceessCount = 0;
            FailCount = 0;
            TotalCount = 0;
            TotalMilliSeconds = 0;
            IsRunning = false;
            SleepTime = sleepTime;
        }

        public void Run()
        {
            m_Running = true;

            if (m_FirstRunDelay > 0)
            {
                Thread.Sleep(m_FirstRunDelay);
            }

            if (m_Running)
            {
                IsRunning = true;

                Stopwatch sw = Stopwatch.StartNew();

                bool success;
                Exception exception = null;
                HttpStatusCode? httpStatusCode = null;

                try
                {
                    HttpWebResponse httpWebResponse = m_HttpRequestRecordProcessor.ProcessRecord(m_Record);
                    httpStatusCode = httpWebResponse.StatusCode;
                    success = true;
                    SucceessCount++;
                }
                catch (WebException ex)
                {
                    LastExceptionStatus = ex.Status;
                    exception = ex;
                    success = false;
                    FailCount++;
                }
                finally
                {
                    TotalCount++;
                }

                sw.Stop();

                double elsapsedMilliSeconds = sw.Elapsed.TotalMilliseconds;

                TotalMilliSeconds += elsapsedMilliSeconds;

                HttpRequestProcessed onHttpRequestProcessed = HttpRequestProcessed;
                onHttpRequestProcessed(this, new HttpRequestProcessedResult(m_Record, success, elsapsedMilliSeconds, httpStatusCode, exception, LastExceptionStatus));

                IsRunning = false;

                if (SleepTime > 0)
                {
                    Thread.Sleep(SleepTime);
                }
            }
        }
    }
}
