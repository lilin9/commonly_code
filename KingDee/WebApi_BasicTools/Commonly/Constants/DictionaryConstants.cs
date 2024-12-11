namespace Commonly.Constants {
	/// <summary>
	/// 这里存放全局管理，但是需要 key-value 形式存储的字面量
	/// </summary>
	public static class DictionaryConstants {
		/// <summary>
		/// 美元的数据库标识
		/// </summary>
		public static string Cny { get; } = "PRE001";
		/// <summary>
		/// 人民币的数据库标识
		/// </summary>
		public static string Usd { get; } = "PRE007";
		/// <summary>
		/// 审核通过的枚举值
		/// </summary>
		public static string IsApproved { get; } = "C";

	}
}
