using System.Runtime.Serialization;

namespace JupyterSharp.Common
{
    [DataContract]
    public class FileSystemEntity
    {
        /// <summary>
        /// Name of file or directory, equivalent to the last part of the path
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// Full path for file or directory
        /// </summary>
        [DataMember]
        public string path { get; set; }
        /// <summary>
        /// Type of content [direcotyr, file, notebook]
        /// </summary>
        [DataMember]
        public string type { get; set; }
        /// <summary>
        /// indicates whether the requester has permission to edit the file
        /// </summary>
        [DataMember]
        public bool writable { get; set; }
        /// <summary>
        /// Creation timestamp
        /// </summary>
        [DataMember]
        public string created { get; set; }
        /// <summary>
        /// Last modified timestamp
        /// </summary>
        [DataMember]
        public string last_modified { get; set; }
        /// <summary>
        /// The size of the file or notebook in bytes. If no size is provided, defaults to null.
        /// </summary>
        [DataMember]
        public int size { get; set; }
        /// <summary>
        /// The mimetype of a file. If content is not null, and type is 'file', this will contain the mimetype of the file, otherwise this will be null.
        /// </summary>
        [DataMember]
        public string mimetype { get; set; }
        /// <summary>
        /// The content, if requested (otherwise null). Will be an array if type is 'directory'
        /// </summary>
        [DataMember]
        public string content { get; set; }
        /// <summary>
        /// Format of content (one of null, 'text', 'base64', 'json')
        /// </summary>
        [DataMember]
        public string format { get; set; }
    }

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
