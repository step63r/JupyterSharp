using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace JupyterSharp
{
    internal class Base64
    {
        // 指定した通常の文字列をUTF-8としてBase64文字列に変換する
        internal static string Encode(string str)
        {
            return Encode(str, Encoding.UTF8);
        }
        // 上記のエンコードが指定できるバージョン
        internal static string Encode(string str, Encoding encode)
        {
            return Convert.ToBase64String(encode.GetBytes(str));
        }

        // 指定したBase64文字列をUTF-8として通常の文字列に変換する
        internal static string Decode(string base64Str)
        {
            return Decode(base64Str, Encoding.UTF8);
        }
        // 上記のエンコードが指定できるバージョン
        internal static string Decode(string base64Str, Encoding encode)
        {
            return encode.GetString(Convert.FromBase64String(base64Str));
        }
    }

    [DataContract]
    internal class FileSystemEntity
    {
        [DataMember()]
        internal string name { get; set; }

        [DataMember()]
        internal string path { get; set; }

        [DataMember()]
        internal string type { get; set; }

        [DataMember()]
        internal string created { get; set; }

        [DataMember()]
        internal string last_modified { get; set; }

        [DataMember()]
        internal List<FileSystemEntity> content { get; set; }

        [DataMember()]
        internal string mimetype { get; set; }

        [DataMember()]
        internal string format { get; set; }
    }

    [DataContract]
    internal class ContentsPutRequest
    {
        /// <summary>
        /// The new filename if changed
        /// </summary>
        [DataMember()]
        internal string name { get; set; }

        /// <summary>
        /// New path for file or directory
        /// </summary>
        [DataMember()]
        internal string path { get; set; }

        /// <summary>
        /// Path dtype ('notebook', 'file', 'directory')
        /// </summary>
        [DataMember()]
        internal string type { get; set; }

        /// <summary>
        /// File format ('json', 'text', 'base64')
        /// </summary>
        [DataMember()]
        internal string format { get; set; }

        /// <summary>
        /// The actual body of the document excluding directory type
        /// </summary>
        [DataMember()]
        internal string content { get; set; }
    }
}
