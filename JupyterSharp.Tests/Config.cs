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
        /// アクセストークン
        /// </summary>
        private static readonly string TestToken = Properties.Settings.Default.JupyterToken;

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
