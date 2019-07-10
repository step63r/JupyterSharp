using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;
using System.Collections.Generic;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Config
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Config()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

        /// <summary>
        /// 設定情報が取得できること
        /// </summary>
        [TestMethod]
        public void GetConfigOK()
        {
            // 設定情報取得
            var getRequest = TestAPI.GetConfig("Application");
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }

        /// <summary>
        /// 設定情報が更新できること
        /// </summary>
        [TestMethod]
        public void UpdateConfigOK()
        {
            // 設定情報更新（ログの日付フォーマットをデフォルト値に設定）
            var updateObject = new Dictionary<string, object>()
            {
                {  "log_datefmt", "%Y-%m-%d %H:%M:%S" }
            };
            var updateRequest = TestAPI.UpdateConfig("Application", updateObject);
            Assert.AreEqual(HttpStatusCode.OK, updateRequest.StatusCode);
        }
    }
}
