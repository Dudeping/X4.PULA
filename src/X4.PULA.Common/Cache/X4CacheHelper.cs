using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X4.PULA.Common.Cache
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public class X4CacheHelper
    {
        /// <summary>
        /// 当前缓存对象
        /// </summary>
        public static IX4Cache CurrentCache { get; set; } = new HttpRuntimeCache(); // 切换缓存对象

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void AddCache(string key, object value)
        {
            CurrentCache.AddCache(key, value);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="extDate">过期时间</param>
        public static void AddCache(string key, object value, DateTime extDate)
        {
            CurrentCache.AddCache(key, value, extDate);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key">键</param>
        public static void Delete(string key)
        {
            CurrentCache.Delete(key);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要更改到的值</param>
        public static void SetCache(string key, object value)
        {
            CurrentCache.SetCache(key, value);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要更改到的值</param>
        /// <param name="extDate">过期时间</param>
        public static void SetCache(string key, object value, DateTime extDate)
        {
            CurrentCache.SetCache(key, value, extDate);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            return CurrentCache.GetCache(key);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static T GetCache<T>(string key)
        {
            return CurrentCache.GetCache<T>(key);
        }
    }
}
