using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharp.Common
{
    internal class Base64
    {
        internal static string Encode(string str)
        {
            return Encode(str, Encoding.UTF8);
        }

        internal static string Encode(string str, Encoding encode)
        {
            return Convert.ToBase64String(encode.GetBytes(str));
        }

        internal static string Decode(string base64Str)
        {
            return Decode(base64Str, Encoding.UTF8);
        }

        internal static string Decode(string base64Str, Encoding encode)
        {
            return encode.GetString(Convert.FromBase64String(base64Str));
        }
    }
}
