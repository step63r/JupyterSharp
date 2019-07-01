using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Contents
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Contents()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

        /// <summary>
        /// ルートディレクトリのファイル一覧が取得できること
        /// </summary>
        [TestMethod]
        public void GetContentsRootDirectoryOK()
        {
            // ファイル一覧取得
            var getRequest = TestAPI.GetContents();
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }

        /// <summary>
        /// 特定のファイル情報が取得できること
        /// </summary>
        [TestMethod]
        public void GetContentsFileOK()
        {
            // ファイル情報取得
            var getRequest = TestAPI.GetContents("/Documents/T1048250-SSH000001_private");
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }

        /// <summary>
        /// ファイルが作成できること
        /// </summary>
        [TestMethod]
        public void CreateContentOK()
        {
            // ファイル生成
            var createRequest = TestAPI.CreateContent();
            var createResponse = JsonConverter.ToObject<Common.Contents>(createRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createRequest.StatusCode);

            // ファイル削除
            var deleteRequest = TestAPI.DeleteContent(string.Format("/{0}", createResponse.name));
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// ファイル名が変更できること
        /// </summary>
        [TestMethod]
        public void RenameContentOK()
        {
            // ファイル生成
            var createRequest = TestAPI.CreateContent();
            var createResponse = JsonConverter.ToObject<Common.Contents>(createRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createRequest.StatusCode);

            // ファイル名変更
            var renameRequest = TestAPI.RenameContent(string.Format("/{0}", createResponse.name), "RenameContentOK");
            var renameResponse = JsonConverter.ToObject<Common.Contents>(renameRequest.Content);
            Assert.AreEqual(HttpStatusCode.OK, renameRequest.StatusCode);

            // ファイル削除
            var deleteRequest = TestAPI.DeleteContent(string.Format("/{0}", renameResponse.name));
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// ファイルがアップロードできること
        /// </summary>
        [TestMethod]
        public void SaveUploadContentOK()
        {
            string filepath = @"../../../SampleFile.txt";

            // ファイルアップロード
            var uploadRequest = TestAPI.SaveUploadContent(filepath);
            var uploadResponse = JsonConverter.ToObject<Common.Contents>(uploadRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, uploadRequest.StatusCode);

            // ファイル削除
            var deleteRequest = TestAPI.DeleteContent(string.Format("/{0}", uploadResponse.name));
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// ファイルが削除できること
        /// </summary>
        [TestMethod]
        public void DeleteContentOK()
        {
            // ファイル生成
            var createRequest = TestAPI.CreateContent();
            var createResponse = JsonConverter.ToObject<Common.Contents>(createRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createRequest.StatusCode);

            // ファイル削除
            var deleteRequest = TestAPI.DeleteContent(string.Format("/{0}", createResponse.name));
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// Notebookのチェックポイント一覧が取得できること
        /// </summary>
        [TestMethod]
        public void GetCheckpointsOK()
        {
            // ファイル生成
            var createFileRequest = TestAPI.CreateContent();
            var createFileResponse = JsonConverter.ToObject<Common.Contents>(createFileRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createFileRequest.StatusCode);

            // ファイル名変更
            var renameRequest = TestAPI.RenameContent(string.Format("/{0}", createFileResponse.name), "GetCheckpointsOK.ipynb");
            var renameResponse = JsonConverter.ToObject<Common.Contents>(renameRequest.Content);
            Assert.AreEqual(HttpStatusCode.OK, renameRequest.StatusCode);

            // チェックポイント一覧取得
            var createCheckpointRequest = TestAPI.GetCheckpoints();
            Assert.AreEqual(HttpStatusCode.OK, createCheckpointRequest.StatusCode);

            // ファイル削除
            var deleteRequest = TestAPI.DeleteContent(string.Format("/{0}", renameResponse.name));
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// Notebookにチェックポイントを生成できること
        /// </summary>
        [TestMethod]
        public void CreateCheckpointOK()
        {
            // ファイル生成
            var createFileRequest = TestAPI.CreateContent();
            var createFileResponse = JsonConverter.ToObject<Common.Contents>(createFileRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createFileRequest.StatusCode);

            // ファイル名変更
            var renameRequest = TestAPI.RenameContent(string.Format("/{0}", createFileResponse.name), "CreateCheckpointOK.ipynb");
            var renameResponse = JsonConverter.ToObject<Common.Contents>(renameRequest.Content);
            Assert.AreEqual(HttpStatusCode.OK, renameRequest.StatusCode);

            // チェックポイント生成
            var createCheckpointRequest = TestAPI.CreateCheckpoint(string.Format("/{0}", renameResponse.name));
            Assert.AreEqual(HttpStatusCode.Created, createCheckpointRequest.StatusCode);

            // ファイル削除
            var deleteRequest = TestAPI.DeleteContent(string.Format("/{0}", renameResponse.name));
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// Notebookのチェックポイントを復元できること
        /// </summary>
        [TestMethod]
        public void RestoreCheckpointOK()
        {
            // ファイル生成
            var createFileRequest = TestAPI.CreateContent();
            var createFileResponse = JsonConverter.ToObject<Common.Contents>(createFileRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createFileRequest.StatusCode);

            // ファイル名変更
            var renameRequest = TestAPI.RenameContent(string.Format("/{0}", createFileResponse.name), "CreateCheckpointOK.ipynb");
            var renameResponse = JsonConverter.ToObject<Common.Contents>(renameRequest.Content);
            Assert.AreEqual(HttpStatusCode.OK, renameRequest.StatusCode);

            // チェックポイント生成
            var createCheckpointRequest = TestAPI.CreateCheckpoint(string.Format("/{0}", renameResponse.name));
            var createCheckpointResponse = JsonConverter.ToObject<Common.Checkpoints>(createCheckpointRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createCheckpointRequest.StatusCode);

            // チェックポイント復元
            var restoreCheckpointRequest = TestAPI.RestoreCheckpoint(string.Format("/{0}", renameResponse.name), createCheckpointResponse.id);
            Assert.AreEqual(HttpStatusCode.NoContent, restoreCheckpointRequest.StatusCode);

            // ファイル削除
            var deleteRequest = TestAPI.DeleteContent(string.Format("/{0}", renameResponse.name));
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// Notebookのチェックポイントを削除できること
        /// </summary>
        [TestMethod]
        public void DeleteCheckpointOK()
        {
            // ファイル生成
            var createFileRequest = TestAPI.CreateContent();
            var createFileResponse = JsonConverter.ToObject<Common.Contents>(createFileRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createFileRequest.StatusCode);

            // ファイル名変更
            var renameRequest = TestAPI.RenameContent(string.Format("/{0}", createFileResponse.name), "CreateCheckpointOK.ipynb");
            var renameResponse = JsonConverter.ToObject<Common.Contents>(renameRequest.Content);
            Assert.AreEqual(HttpStatusCode.OK, renameRequest.StatusCode);

            // チェックポイント生成
            var createCheckpointRequest = TestAPI.CreateCheckpoint(string.Format("/{0}", renameResponse.name));
            var createCheckpointResponse = JsonConverter.ToObject<Common.Checkpoints>(createCheckpointRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createCheckpointRequest.StatusCode);

            // チェックポイント削除
            var deleteCheckpointRequest = TestAPI.DeleteCheckpoint(string.Format("/{0}", renameResponse.name), createCheckpointResponse.id);
            Assert.AreEqual(HttpStatusCode.NoContent, deleteCheckpointRequest.StatusCode);

            // ファイル削除
            var deleteRequest = TestAPI.DeleteContent(string.Format("/{0}", renameResponse.name));
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }
    }
}
