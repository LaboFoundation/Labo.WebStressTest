namespace Labo.WebStressTool.Core
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public sealed class HttpRequestRecordCollection : List<HttpRequestRecord>
    {
        public HttpRequestRecordCollection()
        {
        }

        public HttpRequestRecordCollection(IEnumerable<HttpRequestRecord> collection)
            : base(collection)
        {
        }

        public HttpRequestRecordCollection(int capacity)
            : base(capacity)
        {
        }
    }
}