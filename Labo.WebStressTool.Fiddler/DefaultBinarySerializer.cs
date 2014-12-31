using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Labo.WebStressTool.Fiddler
{
    public sealed class DefaultBinarySerializer
    {
        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The binary data.</returns>
        public byte[] Serialize(object value)
        {
            byte[] binaryData;

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, value);

                binaryData = ms.ToArray();
            }

            return binaryData;
        }

        /// <summary>
        /// Deserializes the specified binary data.
        /// </summary>
        /// <param name="binaryData">The binary data.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>The deserialized value.</returns>
        public object Deserialize(byte[] binaryData, Type objectType)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(binaryData))
            {
                return formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// Deserializes the specified binary data.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="binaryData">The binary data.</param>
        /// <returns>The deserialized value.</returns>
        public TValue Deserialize<TValue>(byte[] binaryData)
        {
            Type objectType = typeof(TValue);

            return (TValue)Deserialize(binaryData, objectType);
        }
    }
}