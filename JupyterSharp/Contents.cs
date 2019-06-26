using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace JupyterSharp
{
    public partial class Api
    {
        public IRestResponse GetContents(string path = "", string encoding = "UTF-8")
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}", Address, Port)));
            client.Encoding = Encoding.GetEncoding(encoding);

            var request = new RestRequest(string.Format("{0}{1}", EndPoints.Contents, path), Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        public IRestResponse PutContents(string srcpath, string dstpath = "", string encoding = "UTF-8")
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}", Address, Port)));
            client.Encoding = Encoding.GetEncoding(encoding);

            dstpath = string.IsNullOrEmpty(dstpath) ? "/" : dstpath;
            //var request = new RestRequest(string.Format("{0}{1}", dstpath, Path.GetFileName(srcpath)), Method.PUT);
            var request = new RestRequest(string.Format("{0}{1}", EndPoints.Contents, dstpath), Method.PUT);
            //request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");


            string enc_content = "";
            using (var sr = new StreamReader(new FileStream(srcpath, FileMode.Open)))
            {
                string content = sr.ReadToEnd();
                enc_content = Base64.Encode(content);
            }

            var postData = new ContentsPutRequest()
            {
                name = Path.GetFileName(srcpath),
                path = srcpath,
                type = "file",
                format = "base64",
                content = enc_content
            };

            request.AddJsonBody(postData);
            var response = client.Execute(request);

            return response;
        }
    }
}
