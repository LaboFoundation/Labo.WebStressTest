using System.IO;
using System.Text;
using Labo.WebStressTool.Core;

namespace Labo.WebStressTool.Fiddler
{
    public sealed class HttpRequestRecordManager
    {
        public void Save(HttpRequestRecordCollection collection, string saveFileName)
        {
            DefaultBinarySerializer binarySerializer = new DefaultBinarySerializer();

            File.WriteAllBytes(saveFileName, binarySerializer.Serialize(collection));
        }

        public HttpRequestRecordCollection Load(string fileName)
        {
            DefaultBinarySerializer binarySerializer = new DefaultBinarySerializer();

            return binarySerializer.Deserialize<HttpRequestRecordCollection>(File.ReadAllBytes(fileName));
        }
    }
}
