using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class ApiSpec
    {
        /// <summary>
        /// アクセストークン
        /// </summary>
        private static readonly string TestToken = Properties.Settings.Default.JupyterToken;

        /// <summary>
        /// Jupyter Notebook Server APIスペックが取得できること
        /// </summary>
        [TestMethod]
        public void GetApiSpecOK()
        {

        }
    }
}
