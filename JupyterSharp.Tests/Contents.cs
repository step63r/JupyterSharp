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
        /// アクセストークン
        /// </summary>
        private static readonly string TestToken = Properties.Settings.Default.JupyterToken;

        /// <summary>
        /// ルートディレクトリのファイル一覧が取得できること
        /// </summary>
        [TestMethod]
        public void GetContentsRootDirectoryOK()
        {
            var api = new Api(TestToken);
            var ret = api.GetContents();
            Assert.AreEqual(HttpStatusCode.OK, ret.StatusCode);
        }

        /// <summary>
        /// 特定のファイル情報が取得できること
        /// </summary>
        [TestMethod]
        public void GetContentsFileOK()
        {
            var api = new Api(TestToken);
            var ret = api.GetContents("/Documents/T1048250-SSH000001_private");
            Assert.AreEqual(HttpStatusCode.OK, ret.StatusCode);
        }

        /// <summary>
        /// ファイルが作成できること
        /// </summary>
        [TestMethod]
        public void CreateContentOK()
        {
            var api = new Api(TestToken);
            var ret = api.CreateContent();
            Assert.AreEqual(HttpStatusCode.Created, ret.StatusCode);
        }

        /// <summary>
        /// ファイル名が変更できること
        /// </summary>
        [TestMethod]
        public void RenameContentOK()
        {
            var api = new Api(TestToken);
            var create = api.CreateContent();
            var createResult = JsonConverter.ToObject<Common.Contents>(create.Content);
            Assert.AreEqual(HttpStatusCode.Created, create.StatusCode);
            var rename = api.RenameContent(string.Format("/{0}", createResult.name), "RENAMED");
            Assert.AreEqual(HttpStatusCode.OK, rename.StatusCode);
        }

        /// <summary>
        /// ファイルがアップロードできること
        /// </summary>
        [TestMethod]
        public void SaveUploadContentOK()
        {
            string filepath = @"../../../SampleFile.txt";

            var api = new Api(TestToken);
            var ret = api.SaveUploadContent(filepath);
            Assert.AreEqual(HttpStatusCode.Created, ret.StatusCode);
        }

        /// <summary>
        /// ファイルが削除できること
        /// </summary>
        [TestMethod]
        public void DeleteContentOK()
        {
            var api = new Api(TestToken);
            var create = api.CreateContent();
            var createResult = JsonConverter.ToObject<Common.Contents>(create.Content);
            Assert.AreEqual(HttpStatusCode.Created, create.StatusCode);
            var delete = api.DeleteContent(string.Format("/{0}", createResult.name));
            Assert.AreEqual(HttpStatusCode.NoContent, delete.StatusCode);
        }

        /// <summary>
        /// Notebookのチェックポイント一覧が取得できること
        /// </summary>
        [TestMethod]
        public void GetCheckpointsOK()
        {

        }

        /// <summary>
        /// Notebookにチェックポイントを生成できること
        /// </summary>
        [TestMethod]
        public void CreateCheckpointOK()
        {

        }

        /// <summary>
        /// Notebookのチェックポイントを復元できること
        /// </summary>
        [TestMethod]
        public void RestoreCheckpointOK()
        {

        }

        /// <summary>
        /// Notebookのチェックポイントを削除できること
        /// </summary>
        [TestMethod]
        public void DeleteCheckpointOK()
        {

        }
    }
}
