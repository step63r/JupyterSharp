namespace JupyterSharp
{
    /// <summary>
    /// EndPoints of Jupyter API
    /// </summary>
    public class EndPoints
    {
        /// <summary>
        /// Notebook and file contents API
        /// </summary>
        internal static string Contents = @"/api/contents";
        /// <summary>
        /// Sessions API
        /// </summary>
        internal static string Sessions = @"/api/sessions";
        /// <summary>
        /// Kernels API
        /// </summary>
        internal static string Kernels = @"/api/kernels";
        /// <summary>
        /// Kernelspecs API
        /// </summary>
        internal static string Kernelspecs = @"/api/kernelspecs";
        /// <summary>
        /// Config API
        /// </summary>
        internal static string Confg = @"/api/config";
        /// <summary>
        /// Terminals API
        /// </summary>
        internal static string Terminals = @"/api/terminals";
        /// <summary>
        /// Status API
        /// </summary>
        internal static string Status = @"/api/status";
        /// <summary>
        /// API Spec
        /// </summary>
        internal static string ApiSpec = @"/api/spec.yaml";
    }
}
