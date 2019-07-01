using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Sessions
    {
        /// <summary>
        /// アクセストークン
        /// </summary>
        private static readonly string TestToken = Properties.Settings.Default.JupyterToken;

        /// <summary>
        /// セッション情報を取得できること
        /// </summary>
        [TestMethod]
        public void GetSessionOK()
        {

        }

        /// <summary>
        /// セッション名を変更できること
        /// </summary>
        [TestMethod]
        public void RenameSessionOK()
        {

        }

        /// <summary>
        /// セッションを削除できること
        /// </summary>
        [TestMethod]
        public void DeleteSessionOK()
        {

        }

        /// <summary>
        /// 利用可能なセッション一覧を取得できること
        /// </summary>
        [TestMethod]
        public void GetSessionsOK()
        {

        }

        /// <summary>
        /// セッションを生成できること
        /// </summary>
        [TestMethod]
        public void CreateSessionOK()
        {

        }
    }
}
