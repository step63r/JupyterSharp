using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Status
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Status()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

        /// <summary>
        /// サーバステータスを取得できること
        /// </summary>
        [TestMethod]
        public void GetStatusOK()
        {
            var getRequest = TestAPI.GetStatus();
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }
    }
}
