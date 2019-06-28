using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharp
{
    public partial class Api
    {
        /// <summary>
        /// Get the current spec for the notebook server's APIs
        /// </summary>
        /// <returns></returns>
        public IRestResponse GetApiSpec()
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}", Address, Port, EndPoints.ApiSpec)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }
    }
}
