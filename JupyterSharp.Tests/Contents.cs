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
        private static string TestToken = "add8cc6e1b4ea33806d6350eb478bb0c77a75449587c013b";

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
        public void PostContentsOK()
        {
            var api = new Api(TestToken);
            var ret = api.PostContents();
            Assert.AreEqual(HttpStatusCode.Created, ret.StatusCode);
        }

        /// <summary>
        /// ファイル名が変更できること
        /// </summary>
        [TestMethod]
        public void PatchContentsFileOK()
        {
            var api = new Api(TestToken);
            var create = api.PostContents();
            var createResult = JsonConverter.ToObject<FileSystemEntity>(create.Content);
            Assert.AreEqual(HttpStatusCode.Created, create.StatusCode);
            var rename = api.PatchContents(string.Format("/{0}", createResult.name), "RENAMED");
            Assert.AreEqual(HttpStatusCode.OK, rename.StatusCode);
        }

        /// <summary>
        /// ファイルがアップロードできること
        /// </summary>
        [TestMethod]
        public void PutContentsOK()
        {
            string filepath = @"../../../SampleFile.txt";

            var api = new Api(TestToken);
            var ret = api.PutContents(filepath);
            Assert.AreEqual(HttpStatusCode.Created, ret.StatusCode);
        }

        [TestMethod]
        public void DeleteContentsOK()
        {
            var api = new Api(TestToken);
            var create = api.PostContents();
            var createResult = JsonConverter.ToObject<FileSystemEntity>(create.Content);
            Assert.AreEqual(HttpStatusCode.Created, create.StatusCode);
            var delete = api.DeleteContents(string.Format("/{0}", createResult.name));
            Assert.AreEqual(HttpStatusCode.NoContent, delete.StatusCode);
        }
    }
}
