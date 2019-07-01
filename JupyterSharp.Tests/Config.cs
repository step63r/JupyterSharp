using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

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

        }

        /// <summary>
        /// 設定情報が更新できること
        /// </summary>
        [TestMethod]
        public void UpdateConfigOK()
        {

        }
    }
}
