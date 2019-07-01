using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Kernels
    {
        /// <summary>
        /// アクセストークン
        /// </summary>
        private static readonly string TestToken = Properties.Settings.Default.JupyterToken;

        /// <summary>
        /// 起動中のカーネル一覧が取得できること
        /// </summary>
        [TestMethod]
        public void GetKernelsOK()
        {

        }

        /// <summary>
        /// カーネルを起動できること
        /// </summary>
        [TestMethod]
        public void StartKernelOK()
        {

        }

        /// <summary>
        /// カーネル情報を取得できること
        /// </summary>
        [TestMethod]
        public void GetKernelOK()
        {

        }

        /// <summary>
        /// カーネルを停止できること
        /// </summary>
        [TestMethod]
        public void DeleteKernelOK()
        {

        }

        /// <summary>
        /// カーネルを中断できること
        /// </summary>
        [TestMethod]
        public void InterruptKernelOK()
        {

        }

        /// <summary>
        /// カーネルを再起動できること
        /// </summary>
        [TestMethod]
        public void RestartKernelOK()
        {

        }
    }
}
