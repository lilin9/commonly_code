using System.Collections.Generic;

namespace Commonly.Models {
	/// <summary>
	/// 表单列表查询的参数模型
	/// </summary>
	public class BillQueryModel {
		private BillQueryModel() {
		}

		public BillQueryModel(string formId, int topRowCount, int limit, int pageIndex, string filterString, string orderString, List<string> fieldKeys) {
			FormId = formId;
			TopRowCount = topRowCount;
			Limit = limit;
			PageIndex = pageIndex;
			FilterString = filterString;
			OrderString = orderString;
			FieldKeys = fieldKeys;
		}

		public BillQueryModel(Build build) {
			FormId = build.FormId;
			TopRowCount = build.TopRowCount;
			Limit = build.Limit;
			PageIndex = build.PageIndex;
			FilterString = build.FilterString;
			OrderString = build.OrderString;
			FieldKeys = build.FieldKeys;
		}

		public BillQueryModel(string formId, string filterString, string orderString, List<string> fieldKeys) {
			FormId = formId;
			FilterString = filterString;
			OrderString = orderString;
			FieldKeys = fieldKeys;
		}

		public BillQueryModel(string formId, string filterString, List<string> fieldKeys) {
			FormId = formId;
			FilterString = filterString;
			OrderString = "FCreateDate DESC";
			FieldKeys = fieldKeys;
		}

		/// <summary>
		/// 表单ID
		/// </summary>
		public string FormId { get; private set; }

		/// <summary>
		/// 最多允许查询的数量，0或者不要此属性表示不限制
		/// </summary>
		public int TopRowCount { get; private set; } = 0;

		/// <summary>
		/// 分页取数每页允许获取的数据，最大不能超过2000
		/// </summary>
		public int Limit { get; private set; } = 2000;

		/// <summary>
		/// 分页页数，从 1 开始
		/// </summary>
		private int PageIndex { get; set; }

		public int StartRow() {
			if (PageIndex <= 0) {
				PageIndex = 1;
			}
			return Limit * (PageIndex - 1);
		}

		/// <summary>
		/// 过滤条件
		/// 示例：FMaterialId.FNumber='HG_TEST'
		/// </summary>
		public string FilterString { get; private set; }
		/// <summary>
		/// 排序条件
		/// 示例：FID ASC
		/// </summary>
		public string OrderString { get; private set; }

		/// <summary>
		/// 待查询表单的字段列表
		/// </summary>
		public List<string> FieldKeys { get; private set; }

		public class Build {
			public string FormId { get; private set; }
			public Build SetFormId(string formId) {
				FormId = formId;
				return this;
			}

			public int TopRowCount { get; private set; } = 0;
			public Build SetTopRowCount(int topRowCount) {
				TopRowCount = topRowCount;
				return this;
			}

			public int Limit { get; private set; } = 20000;
			public Build SetLimit(int limit) {
				Limit = limit;
				return this;
			}

			public int PageIndex { get; private set; }
			public Build SetPageIndex(int pageIndex) {
				PageIndex = pageIndex;
				return this;
			}

			public string FilterString { get; private set; }
			public Build SetFilterString(string filterString) {
				FilterString = filterString;
				return this;
			}

			public string OrderString { get; private set; }
			public Build SetOrderString(string orderString) {
				OrderString = orderString;
				return this;
			}

			public List<string> FieldKeys { get; private set; }
			public Build SetFieldKeys(List<string> fieldKeys) {
				FieldKeys = fieldKeys;
				return this;
			}
		}
	}
}