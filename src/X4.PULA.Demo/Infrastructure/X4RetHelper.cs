using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X4.PULA.Demo.Infrastructure
{
    /// <summary>
    /// X4 返回值帮助类
    /// </summary>
    public class X4RetHelper
    {
        /// <summary>
        /// 获取返回内容
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="url">跳转链接</param>
        /// <returns></returns>
        public static string GetRetText(string text, string url) => $"<script>alert('{text}');location.href='{url}';</script>";
    }
}