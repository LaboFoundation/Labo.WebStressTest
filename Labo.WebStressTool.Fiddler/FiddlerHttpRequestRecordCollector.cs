using System.Globalization;
using System.Text.RegularExpressions;

namespace Labo.WebStressTool.Fiddler
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Web;

    using global::Fiddler;

    using Labo.WebStressTool.Core;

    public delegate void HttpRequestRecordReceived(FiddlerHttpRequestRecordCollector collector, HttpRequestRecord record);

    public sealed class FiddlerHttpRequestRecordCollector
    {
        private readonly int? m_FiddlerPort;

        private HttpRequestRecordCollection m_HttpRequestRecordCollection;

        private readonly List<string> m_HttpMethodsToCollect;

        private List<string> m_HostNamesToCollect;

        private List<string> m_RegexToExcludeUrls;

        private List<string> m_FileExtensionsToExclude;

        public IList<HttpRequestRecord> Records
        {
            get
            {
                return new ReadOnlyCollection<HttpRequestRecord>(m_HttpRequestRecordCollection);
            }
        }

        public List<string> HttpMethodsToCollect
        {
            get
            {
                return m_HttpMethodsToCollect;
            }
        }

        public List<string> HostNamesToCollect
        {
            get
            {
                return m_HostNamesToCollect ?? (m_HostNamesToCollect = new List<string>());
            }

            set
            {
                m_HostNamesToCollect = value;
            }
        }

        public List<string> RegexToExcludeUrls
        {
            get
            {
                return m_RegexToExcludeUrls ?? (m_RegexToExcludeUrls = new List<string>());
            }

            set
            {
                m_RegexToExcludeUrls = value;
            }
        }

        public List<string> FileExtensionsToExclude
        {
            get
            {
                return m_FileExtensionsToExclude ?? (m_FileExtensionsToExclude = new List<string>());
            }

            set
            {
                m_FileExtensionsToExclude = value;
            }
        }

        public event HttpRequestRecordReceived HttpRequestRecordReceived = delegate { };

        public FiddlerHttpRequestRecordCollector(int? fiddlerPort = null)
        {
            m_FiddlerPort = fiddlerPort;
            m_HttpRequestRecordCollection = new HttpRequestRecordCollection();
            m_HttpMethodsToCollect = new List<string> { "GET", "POST" };
            m_HostNamesToCollect = new List<string>();
            m_FileExtensionsToExclude = new List<string>();
        }

        public void StartCollecting()
        {
            FiddlerApplication.BeforeResponse += FiddlerBeforeResponse;
            FiddlerApplication.Startup(m_FiddlerPort.HasValue ? m_FiddlerPort.Value : 8877, true, true);
        }

        public void StopCollecting()
        {
            FiddlerApplication.BeforeResponse -= FiddlerBeforeResponse;
            FiddlerApplication.Shutdown();
        }

        public void ClearData()
        {
            m_HttpRequestRecordCollection.Clear();
        }

        public void SetCollectedRecords(HttpRequestRecordCollection records)
        {
            m_HttpRequestRecordCollection = records;
        }

        private void FiddlerBeforeResponse(Session session)
        {
            Uri uri = new Uri(session.fullUrl);
            if (FileExtensionsToExclude.Count > 0 && FileExtensionsToExclude.Any(x => string.Equals(x, Path.GetExtension(uri.AbsolutePath), StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            if (HostNamesToCollect.Count > 0 && !HostNamesToCollect.Any(x => string.Equals(x, GetHostAndPort(uri), StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            if (RegexToExcludeUrls.Count > 0 && RegexToExcludeUrls.Any(x => Regex.IsMatch(uri.ToString(), x, RegexOptions.IgnoreCase)))
            {
                return;
            }
           
            NameValueCollection queryData = HttpUtility.ParseQueryString(uri.Query);
            string method = session.oRequest.headers.HTTPMethod;
            if (HttpMethodsToCollect.Count > 0 && !HttpMethodsToCollect.Any(x => string.Equals(x, method, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            NameValueCollection requestHeaders = new NameValueCollection();
            foreach (HTTPHeaderItem httpRequestHeader in session.oRequest.headers)
            {
                requestHeaders.Add(httpRequestHeader.Name, httpRequestHeader.Value);
            }

            string requestContent = (session.RequestBody != null) && (session.RequestBody.Length > 0) ? CONFIG.oHeaderEncoding.GetString(session.RequestBody) : null;
            NameValueCollection postData = !string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(requestContent) ? null : GetRequestPostAsDictionary(requestContent);
            int responseStatus = session.responseCode;

            NameValueCollection responseHeaders = new NameValueCollection();
            foreach (HTTPHeaderItem httpResponseHeader in session.oResponse.headers)
            {
                responseHeaders.Add(httpResponseHeader.Name, httpResponseHeader.Value);
            }

            string responseContent = (session.ResponseBody != null && session.ResponseBody.Length > 0) ? CONFIG.oHeaderEncoding.GetString(session.ResponseBody) : null;

            HttpRequestRecord httpRequestRecord = new HttpRequestRecord(uri, queryData, method, requestHeaders, requestContent, postData, responseStatus, responseHeaders, responseContent);
           
            m_HttpRequestRecordCollection.Add(httpRequestRecord);

            HttpRequestRecordReceived(this, httpRequestRecord);
        }

        private static string GetHostAndPort(Uri uri)
        {
            return uri.IsDefaultPort ? uri.Host : string.Format(CultureInfo.InvariantCulture, "{0}:{1}", uri.Host, uri.Port);
        }

        private static NameValueCollection GetRequestPostAsDictionary(string post)
        {
            if (post == null)
            {
                return new NameValueCollection();
            }

            NameValueCollection result = new NameValueCollection();
            string[] keyValues = post.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < keyValues.Length; i++)
            {
                string keyValue = keyValues[i];
                string[] parts = keyValue.Split(new[] { "=" }, StringSplitOptions.None);
                if (parts.Length > 1)
                {
                    result.Add(HttpUtility.HtmlDecode(parts[0]), parts.Length >= 1 ? HttpUtility.HtmlDecode(parts[1]) : string.Empty);
                }
            }

            return result;
        }
    }
}
