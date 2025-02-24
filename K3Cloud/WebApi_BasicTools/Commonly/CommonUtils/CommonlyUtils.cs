using System;
using System.Collections;
using System.Collections.Generic;
using Commonly.Constants;
using Kingdee.BOS.Orm.DataEntity;
using Kingdee.BOS.Util;

namespace Commonly.CommonUtils {
    /// <summary>
    /// 存放一些常用的工具方法
    /// </summary>
    public static class CommonlyUtils {
		/// <summary>
		/// 判断传入的字符串是否可以解析为数字类型
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool IsNumeric(string str) {
			if (string.IsNullOrEmpty(str)) {
				return false;
			}
			// 尝试解析为整数
			return int.TryParse(str, out _) ||
				   // 尝试解析为双精度浮点数
				   double.TryParse(str, out _) ||
				   // 尝试解析为大浮点数
				   decimal.TryParse(str, out _);
		}

		/// <summary>
		/// 判断一个类型是否可以被遍历
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool IsEnumerable(Type type) {
			//检查是否是泛型类型
			if (!type.IsGenericType) {
				//检查是否实现了IEnumerable接口
				return typeof(IEnumerable).IsAssignableFrom(type);
			}
			//获取泛型类型的定义
			var genericTypeDefinition = type.GetGenericTypeDefinition();
			//检查是否为 IEnumerable<> 类型
			return genericTypeDefinition == typeof(IEnumerable<>);
		}

		/// <summary>
		/// 在 list 列表项中间插入指定的 joinStr，组成一个字符串返回
		/// 举例：
		/// 传入 list=[A, B, C, D]，separator=$
		/// 返回 A$B$C$D
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static string JoinList<T>(List<T> list, string separator) {
			return list == null || list.Count == 0 ? null : string.Join(separator, list);
		}

		/// <summary>
		/// 在 list 列表项中间插入指定的 joinStr，组成一个字符串返回
		/// 举例：
		/// 传入 list=[A, B, C, D]，separator=$, separatorItem="
		/// 返回 "A"$"B"$"C"$"D"
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="separator"></param>
		/// <param name="separatorItem"></param>
		/// <returns></returns>
		public static string JoinList<T>(List<T> list, string separator, string separatorItem) {
			if (list == null || list.Count == 0) {
				return null;
			}

			return separatorItem + string.Join($"{separatorItem}{separator}{separatorItem}", list) + separatorItem;
		}

		/// <summary>
		/// 对collection的指定字段进行重新排序
		/// </summary>
		/// <param name="collection">数据集合</param>
		/// <param name="seqFieldName">序号字段名称</param>
		/// <returns></returns>
		public static void ResetSortForCollection(DynamicObjectCollection collection, string seqFieldName) {
			if (collection == null || collection.Count == 0) {
				return;}

			var count = collection.Count;
			for (var index = 0; index < count; index++) {
				if (collection[index] == null || !collection[index].Contains(seqFieldName)) {
					continue;
				}
				collection[index][seqFieldName] = index + 1;
			}
		}

		/// <summary>
		/// 根据币种标识，获取币种显示在页面上的文本
		/// </summary>
		/// <param name="currencyKey">币种标识</param>
		/// <returns></returns>
		public static string GetCurrencyPageShow(string currencyKey) {
			var showText = "";
			
			//RMB
			if (currencyKey == DictionaryConstants.Cny) {
				showText = ViewConstants.RMB.ToString();
			}
			//USD
			if (currencyKey == DictionaryConstants.Usd) {
				showText = ViewConstants.USD.ToString();
			}

			return showText;
		}

		/// <summary>
		/// 将字符类型的值转换成decimal类型
		/// </summary>
		/// <param name="valueStr"></param>
		/// <param name="defaultResult"></param>
		/// <returns></returns>
		public static decimal TryParseToDecimal(string valueStr, decimal defaultResult=0) {
			if (string.IsNullOrEmpty(valueStr)) {
				return defaultResult;
			}

			var isParse = decimal.TryParse(valueStr, out var result);
			return !isParse ? defaultResult : result;
		}

		/// <summary>
		/// 获取明细列表数据，如果获取不到返回false
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="key"></param>
		/// <param name="entities"></param>
		/// <returns></returns>
		public static bool GetEntities(DynamicObject entity, string key, out DynamicObjectCollection entities) {
			if (entity == null || 
			    string.IsNullOrEmpty(key) || 
			    !entity.Contains(key)) {
				entities = null;
				return false;
			}

			entities = entity[key] as DynamicObjectCollection;
			return entities != null && entities.Count != 0;
		}

	}
}
