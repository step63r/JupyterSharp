using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Contents
    {
        /// <summary>
        /// アクセストークン
        /// </summary>
        private static string TestToken = "9e8d30165c554b77790134de46d4109c3d41feb76e9545b0";

        /// <summary>
        /// ルートディレクトリのファイル一覧が取得できること
        /// </summary>
        [TestMethod]
        public void GetContentsRootDirectoryOK()
        {
            var api = new Api(TestToken);
            var ret = api.GetContents();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, ret.StatusCode);
        }

        /// <summary>
        /// 特定のファイル情報が取得できること
        /// </summary>
        [TestMethod]
        public void GetContentsFileOK()
        {
            var api = new Api(TestToken);
            var ret = api.GetContents("/Documents/T1048250-SSH000001_private");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, ret.StatusCode);
        }

        /// <summary>
        /// ルートディレクトリにファイルがアップロードできること
        /// </summary>
        [TestMethod]
        public void PutContentsRootDirectoryOK()
        {
            string filepath = @"../../../SampleFile.txt";

            var api = new Api(TestToken);
            var ret = api.PutContents(filepath);
            Assert.AreEqual(System.Net.HttpStatusCode.Created, ret.StatusCode);
        }
    }
}
