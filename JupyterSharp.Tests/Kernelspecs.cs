using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Kernelspecs
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Kernelspecs()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

        /// <summary>
        /// カーネルスペックが取得できること
        /// </summary>
        [TestMethod]
        public void GetKernelspecsOK()
        {
            // カーネルスペック取得
            var getRequest = TestAPI.GetKernelspecs();
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }
    }
}
