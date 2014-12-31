namespace Labo.WebStressTool.Core
{
    using System.Collections.Specialized;
    using System.Net;

    public sealed class HttpRequestRecordProcessor
    {
        public HttpWebResponse ProcessRecord(HttpRequestRecord record)
        {
            HttpRequestClient client = new HttpRequestClient(record.Uri);

            NameValueCollection postData = record.PostData;
            foreach (string key in postData)
            {
                client.AddData(key, postData[key]);
            }

            return record.Method == "POST" ? client.PostUrlEncoded() : client.GetWebResponse();
        }
    }
}
