using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Kingdee.BOS.JSON;

namespace Commonly.CommonUtils {
	/// <summary>
	/// 这里存放跟 JSON 操作有关的工具方法
	/// </summary>
	public static class JsonUtils {
		/// <summary>
		/// 返回 JSON 数据中的错误信息。如果没有返回空
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string FindErrorMessage<T>(T obj) {
			var json = Serialize(obj);
			if (obj == null || json.IndexOf("\"IsSuccess\":false", StringComparison.Ordinal) == -1) {
				return string.Empty;
			}
			// var match = Regex.Match(json, "\"Message\":\"([^\"]+)\"");
			var match = Regex.Match(json, "\"Message\":\"(.*?)\",");
			return match.Success ? match.Groups[1].Value : string.Empty;
		}

		/// <summary>
		/// 序列化数据
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string Serialize<T>(T obj) {
			return JsonConverterHelper.Serialize(obj);
		}

		/// <summary>
		/// 反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="json"></param>
		/// <returns></returns>
		public static T Deserialize<T>(string json) {
			return JsonConverterHelper.Deserialize<T>(json);
		}

		/// <summary>
		/// 将对象转换成指定的类型
		/// </summary>
		/// <typeparam name="TOut"></typeparam>
		/// <typeparam name="TIn"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static TOut Conversion<TOut, TIn>(TIn obj) {
			return obj == null ? default : Deserialize<TOut>(Serialize(obj));
		}

		/// <summary>
		/// 将 List<Tuple<string, object>> 类型列表转换成 List<Dictionary<string, object>> 类型列表
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static List<Dictionary<string, object>> ConvertTupleToDictionaryForList(List<Tuple<string, object>> list) {
			if (list == null || list.Count == 0) {
				return null;
			}

			return new List<Dictionary<string, object>> {
				list.ToDictionary(item => item.Item1, item => item.Item2)
			};
		}
	}
}
