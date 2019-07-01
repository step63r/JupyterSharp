using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using JupyterSharp.Common;
using System.Collections.Generic;

namespace JupyterSharp.Tests
{
    [TestClass]
    public class Kernels
    {
        /// <summary>
        /// テスト用APIオブジェクト
        /// </summary>
        public Api TestAPI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Kernels()
        {
            TestAPI = new Api(Properties.Settings.Default.JupyterToken);
        }

        /// <summary>
        /// 起動中のカーネル一覧が取得できること
        /// </summary>
        [TestMethod]
        public void GetKernelsOK()
        {
            // カーネル一覧取得
            var getRequest = TestAPI.GetKernels();
            Assert.AreEqual(HttpStatusCode.OK, getRequest.StatusCode);
        }

        /// <summary>
        /// カーネルを起動できること
        /// </summary>
        [TestMethod]
        public void StartKernelOK()
        {
            // カーネル起動
            var startRequest = TestAPI.StartKernel();
            Assert.AreEqual(HttpStatusCode.Created, startRequest.StatusCode);
        }

        /// <summary>
        /// カーネル情報を取得できること
        /// </summary>
        [TestMethod]
        public void GetKernelOK()
        {
            // カーネル起動
            var startRequest = TestAPI.StartKernel();
            var startResponse = JsonConverter.ToObject<Common.Kernel>(startRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, startRequest.StatusCode);

            // カーネル情報取得
            var getKernelRequest = TestAPI.GetKernel(startResponse.id);
            Assert.AreEqual(HttpStatusCode.OK, getKernelRequest.StatusCode);
        }

        /// <summary>
        /// カーネルを停止できること
        /// </summary>
        [TestMethod]
        public void DeleteKernelOK()
        {
            // カーネル起動
            var startRequest = TestAPI.StartKernel();
            var startResponse = JsonConverter.ToObject<Common.Kernel>(startRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, startRequest.StatusCode);

            // カーネル停止
            var deleteRequest = TestAPI.DeleteKernel(startResponse.id);
            Assert.AreEqual(HttpStatusCode.NoContent, deleteRequest.StatusCode);
        }

        /// <summary>
        /// カーネルを中断できること
        /// </summary>
        [TestMethod]
        public void InterruptKernelOK()
        {
            // カーネル起動
            var startRequest = TestAPI.StartKernel();
            var startResponse = JsonConverter.ToObject<Common.Kernel>(startRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, startRequest.StatusCode);

            // カーネル中断
            var interruptRequest = TestAPI.InterruptKernel(startResponse.id);
            Assert.AreEqual(HttpStatusCode.NoContent, interruptRequest.StatusCode);
        }

        /// <summary>
        /// カーネルを再起動できること
        /// </summary>
        [TestMethod]
        public void RestartKernelOK()
        {
            // カーネル起動
            var startRequest = TestAPI.StartKernel();
            var startResponse = JsonConverter.ToObject<Common.Kernel>(startRequest.Content);
            Assert.AreEqual(HttpStatusCode.Created, startRequest.StatusCode);

            // カーネル再起動
            var restartRequest = TestAPI.RestartKernel(startResponse.id);
            Assert.AreEqual(HttpStatusCode.OK, restartRequest.StatusCode);
        }
    }
}
