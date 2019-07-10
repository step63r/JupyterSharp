using JupyterSharp.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharp
{
    public partial class Api
    {
        /// <summary>
        /// Get session
        /// </summary>
        /// <param name="session">Session UUID</param>
        /// <returns></returns>
        public IRestResponse GetSession(string session)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Sessions, session)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// This can be used to rename the session
        /// </summary>
        /// <param name="kernel">Kernel information</param>
        /// <param name="session">Session UUID</param>
        /// <param name="name">Name of the session</param>
        /// <returns></returns>
        public IRestResponse RenameSession(Kernel kernel, string session, string name)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Sessions, session)));
            var request = new RestRequest(Method.PATCH);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var postData = new Session()
            {
                name = name,
                kernel = kernel
            };

            request.AddJsonBody(postData);
            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Delete a session
        /// </summary>
        /// <param name="session">Session UUID</param>
        /// <returns></returns>
        public IRestResponse DeleteSession(string session)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}/{3}", Address, Port, EndPoints.Sessions, session)));
            var request = new RestRequest(Method.DELETE);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// List available sessions
        /// </summary>
        /// <returns></returns>
        public IRestResponse GetSessions()
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}", Address, Port, EndPoints.Sessions)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Create a new session, or return an existing session if a session of the same name already exists
        /// </summary>
        /// <param name="kernel">Kernel information</param>
        /// <param name="name">Name of the session</param>
        /// <returns></returns>
        public IRestResponse CreateSession(Kernel kernel, string name = "")
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}", Address, Port, EndPoints.Sessions)));
            var request = new RestRequest(Method.POST);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var postData = new Session()
            {
                name = name,
                kernel = kernel
            };

            request.AddJsonBody(postData);
            var response = client.Execute(request);

            return response;
        }
    }
}
