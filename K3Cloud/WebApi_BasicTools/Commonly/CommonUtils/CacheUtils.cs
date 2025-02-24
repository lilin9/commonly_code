using System.Runtime.Remoting.Contexts;
using Kingdee.BOS;
using Kingdee.BOS.Util;

namespace Commonly.CommonUtils {
	/// <summary>
	/// 和缓存有关的工具类
	/// </summary>
	public static class CacheUtils {
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCache(Kingdee.BOS.Context context, string key, object value) {
			if (string.IsNullOrEmpty(key)) {
				return;
			}
			var jsonValue = JsonUtils.Serialize(value);
			CacheUtil.SetCache(context.GetAreaCacheKey(), key, key, jsonValue);
		}

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCache(Kingdee.BOS.Context context, string key) {
            if (string.IsNullOrEmpty(key)) {
                return null;
            }
            return CacheUtil.GetCache(context.GetAreaCacheKey(), key, key);
        }

        /// <summary>
        /// 清空指定的缓存
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        public static void ClearCache(Kingdee.BOS.Context context, string key) {
            if (string.IsNullOrEmpty(key)) {
                return;
            }
            CacheUtil.ClearCache(context.GetAreaCacheKey(), key, key);
        }
	}
}
