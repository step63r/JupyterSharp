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
        /// テストカーネルオブジェクト
        /// </summary>
        public Kernel TestKernel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Sessions()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);

            // カーネル生成
            var startRequest = TestAPI.StartKernel();
            TestKernel = JsonConverter.ToObject<Common.Kernel>(startRequest.Content);
        }

        /// <summary>
        /// セッション情報を取得できること
        /// </summary>
        [TestMethod]
        public void GetSessionOK()
        {
            // セッション生成
            var createRequest = TestAPI.CreateSession(TestKernel, Guid.NewGuid().ToString());
            var createResponse = JsonConverter.ToObject<Session>(createRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createRequest.StatusCode);

            // セッション情報取得
            var getRequest = TestAPI.GetSession(createResponse.id);
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }

        /// <summary>
        /// セッション名を変更できること
        /// </summary>
        [TestMethod]
        public void RenameSessionOK()
        {
            // セッション生成
            var createRequest = TestAPI.CreateSession(TestKernel, Guid.NewGuid().ToString());
            var createResponse = JsonConverter.ToObject<Session>(createRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createRequest.StatusCode);

            // セッション名変更
            var renameRequest = TestAPI.RenameSession(TestKernel, createResponse.id, "TestName");
            Assert.AreEqual(HttpStatusCode.OK, renameRequest.StatusCode);
        }

        /// <summary>
        /// セッションを削除できること
        /// </summary>
        [TestMethod]
        public void DeleteSessionOK()
        {
            // セッション生成
            var createRequest = TestAPI.CreateSession(TestKernel, Guid.NewGuid().ToString());
            var createResponse = JsonConverter.ToObject<Session>(createRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, createRequest.StatusCode);

            // セッション削除
            var deleteRequest = TestAPI.DeleteSession(createResponse.id);
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// 利用可能なセッション一覧を取得できること
        /// </summary>
        [TestMethod]
        public void GetSessionsOK()
        {
            var getRequest = TestAPI.GetSessions();
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }

        /// <summary>
        /// セッションを生成できること
        /// </summary>
        [TestMethod]
        public void CreateSessionOK()
        {
            // セッション生成
            var createRequest = TestAPI.CreateSession(TestKernel, Guid.NewGuid().ToString());
            Assert.AreEqual(HttpStatusCode.Created, createRequest.StatusCode);
        }
    }
}
