using Kingdee.BOS.Util;

namespace Commonly.CommonUtils {
	/// <summary>
	/// 和缓存有关的工具类
	/// </summary>
	public static class CacheUtils {
		/// <summary>
		/// 设置缓存
		/// </summary>
		/// <param name="area"></param>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void SetCache(string area, string key, object value) {
			if (string.IsNullOrEmpty(area) || string.IsNullOrEmpty(key)) {
				return;
			}
			var jsonValue = JsonUtils.Serialize(value);
			CacheUtil.SetCache(area, key, key, jsonValue);
		}
	}
}
