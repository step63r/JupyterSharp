using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class ApiSpec
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ApiSpec()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

        /// <summary>
        /// Jupyter Notebook Server APIスペックが取得できること
        /// </summary>
        [TestMethod]
        public void GetApiSpecOK()
        {
            // APIスペック取得
            var getRequest = TestAPI.GetApiSpec();
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }
    }
}
