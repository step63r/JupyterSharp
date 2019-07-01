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
        /// アクセストークン
        /// </summary>
        private static readonly string TestToken = Properties.Settings.Default.JupyterToken;

        /// <summary>
        /// 利用可能なターミナル一覧を取得できること
        /// </summary>
        [TestMethod]
        public void GetTerminalsOK()
        {

        }

        /// <summary>
        /// ターミナルを生成できること
        /// </summary>
        [TestMethod]
        public void CreateTerminalOK()
        {

        }

        /// <summary>
        /// ターミナル情報を取得できること
        /// </summary>
        [TestMethod]
        public void GetTerminalOK()
        {

        }

        /// <summary>
        /// ターミナルを削除できること
        /// </summary>
        [TestMethod]
        public void DeleteTerminalOK()
        {

        }
    }
}
