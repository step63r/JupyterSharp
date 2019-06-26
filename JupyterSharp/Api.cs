using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharp
{
    public partial class Api
    {
        #region プロパティ
        /// <summary>
        /// アクセストークン
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// IPアドレス
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// ポート番号
        /// </summary>
        public string Port { get; set; }
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="token">アクセストークン</param>
        /// <param name="address">IPアドレス</param>
        /// <param name="port">ポート番号</param>
        public Api(string token, string address="localhost", string port="8888")
        {
            Token = token;
            Address = address;
            Port = port;
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~Api()
        {

        }
    }
}
