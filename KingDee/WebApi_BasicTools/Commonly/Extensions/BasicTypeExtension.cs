using System.Collections;
using System.Globalization;
using Kingdee.BOS.Orm.DataEntity;

namespace Commonly.Extensions {
	/// <summary>
	/// 存放和基本数据类型有关的扩展方法
	/// </summary>
	public static class BasicTypeExtension {
		/// <summary>
		/// 判断一个对象是否为空，或者当其是集合类型时Count是否等于0
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool ExistNullOrEmpty(this object obj) {
			switch (obj) {
				case null:
					return true;
				//如果是集合类型，检查 count 是否是0
				case IEnumerable enumerable: {
					var enumerator = enumerable.GetEnumerator();
					return !enumerator.MoveNext();
				}
				default:
					//普通数据类型，返回 false
					return false;
			}
		}

		/// <summary>
		/// 将newEntities的数据覆盖到entities里面
		/// </summary>
		/// <param name="entities"></param>
		/// <param name="newEntities"></param>
		public static void Reset(this DynamicObjectCollection entities, DynamicObjectCollection newEntities) {
			if (newEntities == null || newEntities.Count == 0) {
				return;
			}
			entities.Clear();
			entities.AddRange(newEntities);
		}

		/// <summary>
		/// 去除decimal类型数据的尾数0，返回其字符串类型数据
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static string ToTrimmedString(this decimal number) {
			return number == 0 ? "0" : number.ToString(CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.');
		}
	}
}
