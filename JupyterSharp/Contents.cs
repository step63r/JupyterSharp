using JupyterSharp.Common;
using RestSharp;
using System;
using System.IO;
using System.Text;

namespace JupyterSharp
{
    public partial class Api
    {
        /// <summary>
        /// Get contents of file or directory
        /// </summary>
        /// <param name="path">Path of file or directory</param>
        /// <returns></returns>
        public IRestResponse GetContents(string path = "/")
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}", Address, Port, EndPoints.Contents, path)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Create a new file in the specified path
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public IRestResponse CreateContent(string path = "/")
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}", Address, Port, EndPoints.Contents, path)));
            var request = new RestRequest(Method.POST);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }

        //public IRestResponse PostContents(ContentsPostRequest body, string path = "/")
        //{

        //}

        public IRestResponse RenameContent(string oldPath, string newPath)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}", Address, Port, EndPoints.Contents, oldPath)));
            var request = new RestRequest(Method.PATCH);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var postData = new ContentsPatchRequest()
            {
                path = newPath
            };

            request.AddJsonBody(postData);
            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Save or upload file
        /// </summary>
        /// <param name="srcpath">Local file path</param>
        /// <param name="dstpath">Remote target directory</param>
        /// <returns></returns>
        public IRestResponse SaveUploadContent(string srcpath, string dstpath = "/")
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}{4}", Address, Port, EndPoints.Contents, dstpath, Path.GetFileName(srcpath))));
            var request = new RestRequest(Method.PUT);

            client.Encoding = Encoding.GetEncoding("UTF-8");
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
                path = dstpath,
                type = "file",
                format = "base64",
                content = enc_content
            };

            request.AddJsonBody(postData);
            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Delete a file in the given path
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public IRestResponse DeleteContent(string path)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}", Address, Port, EndPoints.Contents, path)));
            var request = new RestRequest(Method.DELETE);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Get a list of checkpoints for a file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public IRestResponse GetCheckpoints(string path)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}/checkpoints", Address, Port, EndPoints.Contents, path)));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Create a new checkpoint for a file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public IRestResponse CreateCheckpoint(string path)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}/checkpoints", Address, Port, EndPoints.Contents, path)));
            var request = new RestRequest(Method.POST);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Restore a file to a particular checkpointed state
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="checkpoint_id">Checkpoint ID for a file</param>
        /// <returns></returns>
        public IRestResponse RestoreCheckpoint(string path, string checkpoint_id)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}/checkpoints/{4}", Address, Port, EndPoints.Contents, path, checkpoint_id)));
            var request = new RestRequest(Method.POST);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }

        /// <summary>
        /// Delete a checkpoint
        /// </summary>
        /// <param name="path"></param>
        /// <param name="checkpoint_id"></param>
        /// <returns></returns>
        public IRestResponse DeleteCheckpoint(string path, string checkpoint_id)
        {
            var client = new RestClient(new Uri(string.Format("http://{0}:{1}{2}{3}/checkpoints/{4}", Address, Port, EndPoints.Contents, path, checkpoint_id)));
            var request = new RestRequest(Method.DELETE);

            client.Encoding = Encoding.GetEncoding("UTF-8");
            request.AddHeader("Authorization", string.Format("Token {0}", Token));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);

            return response;
        }
    }
}
