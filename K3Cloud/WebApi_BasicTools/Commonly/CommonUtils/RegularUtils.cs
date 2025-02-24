using System.Text.RegularExpressions;

namespace Commonly.CommonUtils {
	/// <summary>
	/// 这里存放跟正则运算有关的工具方法
	/// </summary>
	public static class RegularUtils {
		//匹配出批号对应的单据编号
		private const string LotPattern = @"^(.*?)(?:-[^-\r\n]*)$";
		//左匹配正则表达式
		private const string LeftMatchedPattern = @"\b{0}[^\s]*";


		/// <summary>
		/// 根据传入的 key 进行正则左匹配
		/// </summary>
		/// <param name="str">需要匹配的字符串</param>
		/// <param name="key">匹配规则关键字</param>
		/// <returns></returns>
		public static bool LeftMatching(string str, string key) {
			var pattern = string.Format(LeftMatchedPattern, key);
			return Regex.IsMatch(str, pattern);
		}

		/// <summary>
		/// 根据传入的正则表达式，返回匹配到的字符串
		/// </summary>
		/// <param name="str">需要匹配的字符串</param>
		/// <param name="pattern">正则表达式</param>
		/// <returns></returns>
		public static string Matching(string str, string pattern) {
			if (string.IsNullOrEmpty(str)) {
				return str;
			}
			var match = Regex.Match(str, pattern);
			return match.Success ? match.Groups[1].Value : null;
		}

		/// <summary>
		/// 校验批号是否是采购入库单批号
		/// 注：采购入库单批号以 "AB-" 开头
		/// </summary>
		/// <param name="lotText"></param>
		/// <returns></returns>
		public static bool IsPurchaseInStorageLot(string lotText) {
			return !string.IsNullOrEmpty(lotText) && LeftMatching(lotText, "AB-");
		}

		/// <summary>
		/// 传入批号，获取批号对应的单据编号
		/// 例如：
		/// lotText：AB-24-10-30-0001-10
		/// return ：AB-24-10-30-0001
		/// </summary>
		/// <param name="lotText"></param>
		/// <returns></returns>
		public static string MatchingLotText(string lotText) {
			return string.IsNullOrEmpty(lotText) ? null : Regex.Replace(lotText, LotPattern, @"$1");
		}
	}
}
