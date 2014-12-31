namespace Labo.WebStressTool.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    [Serializable]
    public sealed class HttpRequestRecord
    {
        private NameValueCollection m_QueryData;

        private NameValueCollection m_PostData;

        private NameValueCollection m_RequestHeaders;

        private NameValueCollection m_ResponseHeaders;

        public Uri Uri { get; private set; }

        public NameValueCollection QueryData
        {
            get
            {
                return m_QueryData ?? (m_QueryData = new NameValueCollection());
            }

            private set
            {
                m_QueryData = value;
            }
        }

        public string Method { get; private set; }

        public NameValueCollection RequestHeaders
        {
            get
            {
                return m_RequestHeaders ?? (m_RequestHeaders = new NameValueCollection());
            }

            private set
            {
                m_RequestHeaders = value;
            }
        }

        public string RequestContent { get; private set; }

        public NameValueCollection PostData
        {
            get
            {
                return m_PostData ?? (m_PostData = new NameValueCollection());
            }

            private set
            {
                m_PostData = value;
            }
        }

        public int ResponseStatus { get; private set; }

        public NameValueCollection ResponseHeaders
        {
            get
            {
                return m_ResponseHeaders ?? (m_ResponseHeaders = new NameValueCollection());
            }

            private set
            {
                m_ResponseHeaders = value;
            }
        }

        public string ResponseContent { get; private set; }

        public bool IsAjaxRequest
        {
            get { return (RequestHeaders != null) && string.Equals(RequestHeaders["X-Requested-With"], "XMLHttpRequest", StringComparison.OrdinalIgnoreCase); }
        }

        public bool IsMicrosoftAjaxRequest
        {
            get { return IsAjaxRequest && string.Equals(RequestHeaders["X-MicrosoftAjax"], "Delta=true", StringComparison.OrdinalIgnoreCase); }
        }

        public HttpRequestRecord(Uri uri, NameValueCollection queryData, string method, NameValueCollection requestHeaders, string requestContent, NameValueCollection postData, int responseStatus, NameValueCollection responseHeaders, string responseContent)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (string.IsNullOrWhiteSpace(method))
            {
                throw new ArgumentNullException("method");
            }

            QueryData = queryData;
            Uri = uri;
            Method = method;
            RequestHeaders = requestHeaders;
            RequestContent = requestContent;
            PostData = postData;
            ResponseStatus = responseStatus;
            ResponseHeaders = responseHeaders;
            ResponseContent = responseContent;
        }
    } 
}
