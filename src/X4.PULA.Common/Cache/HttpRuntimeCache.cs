using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace X4.PULA.Common.Cache
{
    public class HttpRuntimeCache : IX4Cache
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void AddCache(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="extDate">过期时间</param>
        public void AddCache(string key, object value, DateTime extDate)
        {
            HttpRuntime.Cache.Insert(key, value, null, extDate, TimeSpan.Zero);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key">键</param>
        public void Delete(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要更改到的值</param>
        public void SetCache(string key, object value)
        {
            HttpRuntime.Cache.Remove(key);
            HttpRuntime.Cache.Insert(key, value);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要更改到的值</param>
        /// <param name="extDate">过期时间</param>
        public void SetCache(string key, object value, DateTime extDate)
        {
            HttpRuntime.Cache.Remove(key);
            HttpRuntime.Cache.Insert(key, value, null, extDate, TimeSpan.Zero);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public object GetCache(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public T GetCache<T>(string key)
        {
            return (T)HttpRuntime.Cache.Get(key);
        }
    }
}
