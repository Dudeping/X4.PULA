using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X4.PULA.Common.Cache
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface IX4Cache
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        void AddCache(string key, object value);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="extDate">过期时间</param>
        void AddCache(string key, object value, DateTime extDate);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key">键</param>
        void Delete(string key);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要更改到的值</param>
        void SetCache(string key, object value);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要更改到的值</param>
        /// <param name="extDate">过期时间</param>
        void SetCache(string key, object value, DateTime extDate);
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        object GetCache(string key);
        /// <summary>
        /// 查找
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        T GetCache<T>(string key);
    }
}
