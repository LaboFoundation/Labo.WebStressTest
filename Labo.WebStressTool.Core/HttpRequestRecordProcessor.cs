namespace Labo.WebStressTool.Core
{
    using System.Collections.Specialized;
    using System.Net;

    public sealed class HttpRequestRecordProcessor
    {
        public HttpWebResponse ProcessRecord(HttpRequestRecord record, CookieCollection cookies)
        {
            HttpRequestClient client = new HttpRequestClient(record.Uri, record.RequestHeaders, cookies);

            NameValueCollection postData = record.PostData;
            foreach (string key in postData)
            {
                client.AddData(key, postData[key]);
            }

            if (record.Method == "POST")
            {
                if (record.ContentType == "application/json")
                {
                    return client.PostJson(record.RequestContent);
                }

                return client.PostUrlEncoded();
            }
            else
            {
                return client.GetWebResponse();
            }
        }
    }
}
