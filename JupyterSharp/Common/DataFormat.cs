using System.Runtime.Serialization;

namespace JupyterSharp.Common
{
    /// <summary>
    /// Path of file to copy
    /// </summary>
    [DataContract]
    public class ContentsPostRequest
    {
        [DataMember]
        public string copy_from { get; set; }

        [DataMember]
        public string ext { get; set; }

        [DataMember]
        public string type { get; set; }
    }

    /// <summary>
    /// New path for file or directory
    /// </summary>
    [DataContract]
    public class ContentsPatchRequest
    {
        /// <summary>
        /// New path for file or directory
        /// </summary>
        [DataMember]
        public string path { get; set; }
    }

    /// <summary>
    /// New path for file or directory
    /// </summary>
    [DataContract]
    public class ContentsPutRequest
    {
        /// <summary>
        /// The new filename if changed
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// New path for file or directory
        /// </summary>
        [DataMember]
        public string path { get; set; }
        /// <summary>
        /// Path dtype ('notebook', 'file', 'directory')
        /// </summary>
        [DataMember]
        public string type { get; set; }
        /// <summary>
        /// File format ('json', 'text', 'base64')
        /// </summary>
        [DataMember]
        public string format { get; set; }
        /// <summary>
        /// The actual body of the document excluding directory type
        /// </summary>
        [DataMember]
        public string content { get; set; }
    }
}
