namespace Labo.WebStressTool.Core
{
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;

    public sealed class HttpRequestClient
    {
        static HttpRequestClient()
        {
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
        }

        private readonly Uri m_URL;

        private readonly NameValueCollection m_RequestData;

        private readonly NameValueCollection m_RequestHeaders;

        public HttpRequestClient(Uri url, NameValueCollection headers = null)
        {
            m_URL = url;
            m_RequestData = new NameValueCollection();
            m_RequestHeaders = headers;
        }

        public HttpRequestClient(string url, NameValueCollection headers = null)
            : this(new Uri(url), headers)
        {
        }

        public void AddData(string name, string value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            m_RequestData.Add(name, value);
        }

        public HttpWebResponse GetWebResponse()
        {
            const string method = "GET";

            HttpWebRequest request = m_RequestData.Count == 0 ? CreateWebRequest(method) : CreateWebRequest(new Uri(string.Format("{0}?{1}", m_URL, GetRequestParameters())), method);
            request.Method = method;

            return (HttpWebResponse)request.GetResponse();
        }

        public HttpWebResponse PostJson(string requestContent)
        {
            const string method = "POST";

            HttpWebRequest request = CreateWebRequest(method);
            request.Method = method;
            request.ContentType = "application/json";

            using (MemoryStream data = GetJsonData(requestContent))
            {
                request.ContentLength = data.Length;

                Stream requestStream = request.GetRequestStream();

                data.WriteTo(requestStream);

                HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();

                return httpWebResponse;
            }
        }

        private static MemoryStream GetJsonData(string requestContent)
        {
            MemoryStream data = new MemoryStream();
            byte[] dataBytes = Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture, "\r\n{0}", requestContent));
            data.Write(dataBytes, 0, dataBytes.Length);
            return data;
        }

        public HttpWebResponse PostUrlEncoded()
        {
            const string method = "POST";

            HttpWebRequest request = CreateWebRequest(method);
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded";

            using (MemoryStream data = GetUrlEncodedData())
            {
                request.ContentLength = data.Length;

                Stream requestStream = request.GetRequestStream();

                data.WriteTo(requestStream);

                HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();

                return httpWebResponse;
            }
        }

        private static void WriteUrlEncoded(Stream stream, string key, string value)
        {
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            stream.Write(keyBytes, 0, keyBytes.Length);
            stream.WriteByte((byte)'=');
            byte[] valueBytes = Encoding.ASCII.GetBytes(Uri.EscapeDataString(value));
            stream.Write(valueBytes, 0, valueBytes.Length);
        }

        private HttpWebRequest CreateWebRequest(string method)
        {
            return CreateWebRequest(m_URL, method);
        }

        private HttpWebRequest CreateWebRequest(Uri uri, string method)
        {
            const string userAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";

            if (method != "POST")
            {
                HttpWebRequest headRequest = (HttpWebRequest)WebRequest.Create(uri);
                headRequest.AllowAutoRedirect = true;
                headRequest.Method = "HEAD";
                headRequest.UserAgent = userAgent;
                WebResponse webResponse = headRequest.GetResponse();
                uri = webResponse.ResponseUri;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.UserAgent = userAgent;
            request.ServicePoint.Expect100Continue = false;
            request.Timeout = 15 * 1000;

            SetRequestHeaders(request);

            return request;
        }

        private void SetRequestHeaders(HttpWebRequest request)
        {
            if (m_RequestHeaders == null)
            {
                return;
            }

            foreach (string headerKey in m_RequestHeaders)
            {
                switch (headerKey.ToLower(CultureInfo.InvariantCulture))
                {
                    case "host":
                        request.Host = m_RequestHeaders[headerKey];
                        break;
                    case "user-agent":
                        request.UserAgent = m_RequestHeaders[headerKey];
                        break;
                    case "accept":
                        request.Accept = m_RequestHeaders[headerKey];
                        break;
                    case "referer":
                        request.Referer = m_RequestHeaders[headerKey];
                        break;
                    case "content-type":
                        request.ContentType = m_RequestHeaders[headerKey];
                        break;
                    case "if-modified-since":
                        string[] parts = m_RequestHeaders[headerKey].Trim().Split(';');
                        DateTime date;
                        if (DateTime.TryParse(parts[0], out date))
                        {
                            request.IfModifiedSince = date;
                        }

                        break;
                    default:
                        try
                        {
                            request.Headers.Add(headerKey, m_RequestHeaders[headerKey]);
                        }
                        catch (Exception)
                        {
                        }

                        break;
                }
            }
        }

        private MemoryStream GetUrlEncodedData()
        {
            MemoryStream requestStream = new MemoryStream();

            bool first = true;
            foreach (string field in m_RequestData)
            {
                if (!first)
                {
                    requestStream.WriteByte((byte)'&');
                }

                first = false;

                WriteUrlEncoded(requestStream, field, m_RequestData[field]);
            }

            return requestStream;
        }

        private string GetRequestParameters()
        {
            StringBuilder queryString = new StringBuilder();
            bool first = true;
            foreach (string field in m_RequestData)
            {
                if (!first)
                {
                    queryString.Append("&");
                }

                first = false;

                queryString.Append(field);
                queryString.Append("=");
                queryString.Append(Uri.EscapeDataString(m_RequestData[field]));
            }

            return queryString.ToString();
        }
    }
}
