namespace Labo.WebStressTool.Core
{
    using System;
    using System.Net;

    public sealed class HttpRequestProcessedResult
    {
        public HttpRequestRecord HttpRequestRecord { get; private set; }

        public bool Success { get; private set; }

        public double ElapsedMilliseconds { get; private set; }

        public HttpStatusCode? HttpResponseStatusCode { get; private set; }

        public WebExceptionStatus? ExceptionStatus { get; private set; }

        public Exception Exception { get; private set; }

        public HttpRequestProcessedResult(HttpRequestRecord httpRequestRecord, bool success, double elsapsedMilliSeconds, HttpStatusCode? httpResponseStatusCode, Exception exception = null, WebExceptionStatus? webExceptionStatus = null)
        {
            HttpRequestRecord = httpRequestRecord;
            Success = success;
            ElapsedMilliseconds = elsapsedMilliSeconds;
            HttpResponseStatusCode = httpResponseStatusCode;
            Exception = exception;
            ExceptionStatus = webExceptionStatus;
        }
    }
}