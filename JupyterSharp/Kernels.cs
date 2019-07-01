using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharp
{
    public partial class Api
    {
        /// <summary>
        /// List the JSON data for all kernels that are currently running
        /// </summary>
        /// <returns></returns>
        public IRestResponse GetKernels()
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}", Address, Port, EndPoints.Kernels)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Start a kernel and return the uuid
        /// </summary>
        /// <param name="name">Kernel spec name (defaults to default kernel spec for server)</param>
        /// <returns></returns>
        public IRestResponse StartKernel(string name = "")
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}", Address, Port, EndPoints.Kernels)));
            var request = new RestRequest(Method.POST);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            if (!string.IsNullOrEmpty(name))
            {
                var postData = new Dictionary<string, string>()
                {
                    { "name", name }
                };
                request.AddJsonBody(postData);
            }

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Get kernel information
        /// </summary>
        /// <param name="kernel_id">Kernel UUID</param>
        /// <returns></returns>
        public IRestResponse GetKernel(string kernel_id)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Kernels, kernel_id)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Kill a kernel and delete the kernel id
        /// </summary>
        /// <param name="kernel_id">Kernel UUID</param>
        /// <returns></returns>
        public IRestResponse DeleteKernel(string kernel_id)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Kernels, kernel_id)));
            var request = new RestRequest(Method.DELETE);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Interrupt a kernel
        /// </summary>
        /// <param name="kernel_id">Kernel UUID</param>
        /// <returns></returns>
        public IRestResponse InterruptKernel(string kernel_id)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}/interrupt", Address, Port, EndPoints.Kernels, kernel_id)));
            var request = new RestRequest(Method.POST);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Restart a kernel
        /// </summary>
        /// <param name="kernel_id">Kernel UUID</param>
        /// <returns></returns>
        public IRestResponse RestartKernel(string kernel_id)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}/restart", Address, Port, EndPoints.Kernels, kernel_id)));
            var request = new RestRequest(Method.POST);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }
    }
}
