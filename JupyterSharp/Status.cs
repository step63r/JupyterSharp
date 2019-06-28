using RestSharp;
using System;

namespace JupyterSharp
{
    public partial class Api
    {
        /// <summary>
        /// Get the current status/activity of the server
        /// </summary>
        /// <returns></returns>
        public IRestResponse GetStatus()
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}", Address, Port, EndPoints.Status)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }
    }
}
