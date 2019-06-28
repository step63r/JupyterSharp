using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JupyterSharp.Common
{
    /// <summary>
    /// Notebook server API status. Added in notebook 5.0
    /// </summary>
    [DataContract]
    public class APIStatus
    {
        /// <summary>
        /// ISO8601 timestamp indicating when the notebook server started
        /// </summary>
        [DataMember]
        public string started { get; set; }
        /// <summary>
        /// ISO8601 timestamp indicating the last activity on the server, either on the REST API or kernel activity
        /// </summary>
        [DataMember]
        public string last_activity { get; set; }
        /// <summary>
        /// The total number of currently open connections to kernels
        /// </summary>
        [DataMember]
        public int connections { get; set; }
        /// <summary>
        /// The total number of running kernels
        /// </summary>
        [DataMember]
        public int kernels { get; set; }
    }

    /// <summary>
    /// Kernel spec (contents of kernel.json)
    /// </summary>
    [DataContract]
    public class KernelSpec
    {
        /// <summary>
        /// Unique name for kernel
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// Kernel spec json file
        /// </summary>
        [DataMember]
        public KernelSpecFile KernelSpecFile { get; set; }
        /// <summary>
        /// Path dictionary of kernel.js, kernel.css and logo-*
        /// </summary>
        [DataMember]
        public Dictionary<string, string> resources { get; set; }
    }

    /// <summary>
    /// Kernel spec json file
    /// </summary>
    [DataContract]
    public class KernelSpecFile
    {
        /// <summary>
        /// The programming language which this kernel runs. This will be stored in notebook metadata
        /// </summary>
        [DataMember]
        public string language { get; set; }
        /// <summary>
        /// A list of command line arguments used to start the kernel. The text {connection_file} in any argument will be replaced with the path to the connection file
        /// </summary>
        [DataMember]
        public List<string> argv { get; set; }
        /// <summary>
        /// The kernel's name as it should be displayed in the UI. Unlike the kernel name used in the API, this can contain arbitrary unicode characters
        /// </summary>
        [DataMember]
        public string display_name { get; set; }
        /// <summary>
        /// Codemirror mode. Can be a string or an valid Codemirror mode object. This defaults to the string from the language property
        /// </summary>
        [DataMember]
        public string codemirror_mode { get; set; }
        /// <summary>
        /// A dictionary of environment variables to set for the kernel. These will be added to the current environment variables
        /// </summary>
        [DataMember]
        public Dictionary<string, object> env { get; set; }
        /// <summary>
        /// Help items to be displayed in the help menu in the notebook UI
        /// </summary>
        [DataMember]
        public List<Dictionary<string, string>> help_links { get; set; }
    }

    /// <summary>
    /// Kernel information
    /// </summary>
    [DataContract]
    public class Kernel
    {
        /// <summary>
        /// uuid of kernel
        /// </summary>
        [DataMember]
        public string id { get; set; }
        /// <summary>
        /// kernel spec name
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// ISO 8601 timestamp for the last-seen activity on this kernel
        /// </summary>
        [DataMember]
        public string last_activity { get; set; }
        /// <summary>
        /// The number of active connections to this kernel
        /// </summary>
        [DataMember]
        public int connections { get; set; }
        /// <summary>
        /// Current execution state of the kernel
        /// </summary>
        [DataMember]
        public string execution_state { get; set; }
    }

    /// <summary>
    /// A session
    /// </summary>
    [DataContract]
    public class Session
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string id { get; set; }
        /// <summary>
        /// path to the session
        /// </summary>
        [DataMember]
        public string path { get; set; }
        /// <summary>
        /// name of the session
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// session type
        /// </summary>
        [DataMember]
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Kernel kernel { get; set; }
    }

    /// <summary>
    /// A contents object. The content and format keys may be null if content is not contained. If type is 'file', then the mimetype will be null
    /// </summary>
    [DataContract]
    public class Contents
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
        /// Type of content [directory, file, notebook]
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
        /// The size of the file or notebook in bytes. If no size is provided, defaults to null
        /// </summary>
        [DataMember]
        public int? size { get; set; }
        /// <summary>
        /// The mimetype of a file. If content is not null, and type is 'file', this will contain the mimetype of the file, otherwise this will be null
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
    /// A checkpoint object
    /// </summary>
    [DataContract]
    public class Checkpoints
    {
        /// <summary>
        /// Unique id for the checkpoint
        /// </summary>
        [DataMember]
        public string id { get; set; }
        /// <summary>
        /// Last modified timestamp
        /// </summary>
        [DataMember]
        public string last_modified { get; set; }
    }

    /// <summary>
    /// A Terminal_ID object
    /// </summary>
    [DataContract]
    public class Terminal_ID
    {
        /// <summary>
        /// name of terminal ID
        /// </summary>
        [DataMember]
        public string name { get; set; }
    }
}
