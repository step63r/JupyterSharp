using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharp
{
    public partial class Api
    {
        /// <summary>
        /// Get a configuration section by name
        /// </summary>
        /// <param name="section_name">Name of config section</param>
        /// <returns></returns>
        public IRestResponse GetConfig(string section_name)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Confg, section_name)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Update a configuration section by name
        /// </summary>
        /// <param name="section_name">Name of config section</param>
        /// <param name="configration">Config object</param>
        /// <returns></returns>
        public IRestResponse UpdateConfig(string section_name, Dictionary<string, object> configration = null)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Confg, section_name)));
            var request = new RestRequest(Method.PATCH);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var postData = configration ?? new Dictionary<string, object>();

            request.AddJsonBody(postData);
            var response = client.Execute(request);

            return response;
        }
    }
}
