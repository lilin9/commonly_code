using System.Collections;

namespace Commonly.Extensions {
    public static class ObjectExtensions {

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
        /// 去除decimal类型数据的尾数0，返回其字符串类型数据
        /// </summary>
        /// <param name="numberObj"></param>
        /// <returns></returns>
        public static string ToTrimmedString(this object numberObj) {
			if(numberObj == null) {
                return "0";
            }
			var number = (decimal) numberObj;
            if (number == 0) {
                return "0";
            }

            var number2 = number / 1.000000000000000000000000000000000000000000000000000000m;
            return number2.ToString("G29");
        }
	}
}
