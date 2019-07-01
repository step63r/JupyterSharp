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
        /// アクセストークン
        /// </summary>
        private static readonly string TestToken = Properties.Settings.Default.JupyterToken;

        /// <summary>
        /// カーネルスペックが取得できること
        /// </summary>
        [TestMethod]
        public void GetKernelspecsOK()
        {

        }
    }
}
