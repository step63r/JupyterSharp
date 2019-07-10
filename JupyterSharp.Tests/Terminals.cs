using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Terminals
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Terminals()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

        /// <summary>
        /// 利用可能なターミナル一覧を取得できること
        /// </summary>
        [TestMethod]
        public void GetTerminalsOK()
        {
            // ターミナル一覧取得
            var getRequest = TestAPI.GetTerminals();
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }

        /// <summary>
        /// ターミナルを生成できること
        /// </summary>
        [TestMethod]
        public void CreateTerminalOK()
        {
            // ターミナル生成
            var createRequest = TestAPI.CreateTerminal();
            Assert.AreEqual(HttpStatusCode.OK, createRequest.StatusCode);
        }

        /// <summary>
        /// ターミナル情報を取得できること
        /// </summary>
        [TestMethod]
        public void GetTerminalOK()
        {
            // ターミナル生成
            var createRequest = TestAPI.CreateTerminal();
            var createResponse = JsonConverter.ToObject<Common.Terminal_ID>(createRequest.Content);
            Assert.AreEqual(HttpStatusCode.OK, createRequest.StatusCode);

            // ターミナル情報取得
            var getRequest = TestAPI.GetTerminal(createResponse.name);
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }

        /// <summary>
        /// ターミナルを削除できること
        /// </summary>
        [TestMethod]
        public void DeleteTerminalOK()
        {
            // ターミナル生成
            var createRequest = TestAPI.CreateTerminal();
            var createResponse = JsonConverter.ToObject<Common.Terminal_ID>(createRequest.Content);
            Assert.AreEqual(HttpStatusCode.OK, createRequest.StatusCode);

            // ターミナル削除
            var deleteRequest = TestAPI.DeleteTerminal(createResponse.name);
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }
    }
}
