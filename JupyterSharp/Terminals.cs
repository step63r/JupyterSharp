using RestSharp;
using System;

namespace JupyterSharp
{
    public partial class Api
    {
        /// <summary>
        /// Get available terminals
        /// </summary>
        /// <returns></returns>
        public IRestResponse GetTerminals()
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}", Address, Port, EndPoints.Terminals)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Create a new terminal
        /// </summary>
        /// <returns></returns>
        public IRestResponse CreateTerminal()
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}", Address, Port, EndPoints.Terminals)));
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Get a terminal session corresponding to an id
        /// </summary>
        /// <param name="terminal_id">ID of terminal session</param>
        /// <returns></returns>
        public IRestResponse GetTerminal(string terminal_id)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Terminals, terminal_id)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Delete a terminal session corresponding to an id
        /// </summary>
        /// <param name="terminal_id">ID of terminal session</param>
        /// <returns></returns>
        public IRestResponse DeleteTerminal(string terminal_id)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Terminals, terminal_id)));
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }
    }
}
