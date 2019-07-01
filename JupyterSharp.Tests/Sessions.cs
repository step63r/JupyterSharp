using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Sessions
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Sessions()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

        /// <summary>
        /// セッション情報を取得できること
        /// </summary>
        [TestMethod]
        public void GetSessionOK()
        {

        }

        /// <summary>
        /// セッション名を変更できること
        /// </summary>
        [TestMethod]
        public void RenameSessionOK()
        {

        }

        /// <summary>
        /// セッションを削除できること
        /// </summary>
        [TestMethod]
        public void DeleteSessionOK()
        {

        }

        /// <summary>
        /// 利用可能なセッション一覧を取得できること
        /// </summary>
        [TestMethod]
        public void GetSessionsOK()
        {

        }

        /// <summary>
        /// セッションを生成できること
        /// </summary>
        [TestMethod]
        public void CreateSessionOK()
        {
            // TODO: (r-uchiyama) カーネルの取得が必要かもしれない
            var createRequest = TestAPI.CreateSession();
            Assert.AreEqual(HttpStatusCode.Created, createRequest.StatusCode);
        }
    }
}
