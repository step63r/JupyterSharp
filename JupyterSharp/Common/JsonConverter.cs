using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JupyterSharp.Common
{
    public static class JsonConverter
    {
        public static string ToJson<T>(this T data)
        {
            string json = null;
            var stream = new MemoryStream();
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, data);
                json = Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                stream.Dispose();
            }
            return json;
        }

        public static T ToObject<T>(this string json)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var data = default(T);
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                stream.Dispose();
            }
            return data;
        }
    }
}
