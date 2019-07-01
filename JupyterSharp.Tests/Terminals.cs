﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Terminals
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Terminals()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

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
