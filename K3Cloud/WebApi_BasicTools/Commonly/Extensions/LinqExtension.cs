using System;
using System.Collections.Generic;
using System.Linq;
using Kingdee.BOS.Orm.DataEntity;

namespace Commonly.Extensions {
	/// <summary>
	/// 和 linq 语法有关的扩展方法
	/// </summary>
	public static class LinqExtension {

		/// <summary>
		/// DynamicObjectCollection集合的ForEach循环
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="action"></param>
		public static void ForEach(this DynamicObjectCollection collection, Action<DynamicObject> action) {
			foreach (var item in collection) {
				action(item);
			}
		}

		/// <summary>
		/// 将传入的列表转换成DynamicObjectCollection集合
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static DynamicObjectCollection ToCollection(this IEnumerable<DynamicObject> list) {
			var collection = new DynamicObjectCollection();
			foreach (var obj in list) {
				collection.Add(obj);
			}
			return collection;
		}

		/// <summary>
		/// 批量删除扩展方法
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="predicate"></param>
		public static void RemoveAll(this DynamicObjectCollection collection, Func<DynamicObject, bool> predicate) {
			var removeList = collection.Where(predicate).ToList();
			removeList.ForEach(item => collection.Remove(item));
		}

		/// <summary>
		/// 批量添加
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="newCollection"></param>
		public static void AddRange(this DynamicObjectCollection collection, DynamicObjectCollection newCollection) {
			newCollection.ForEach(collection.Add);
		}
	}
}
