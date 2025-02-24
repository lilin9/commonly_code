using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Commonly.Models {
	/// <summary>
	/// 下推接口的参数模型
	/// </summary>
	public class PushModel {
		private PushModel() { }

		public PushModel(string formId, 
			List<string> ids, 
			List<string> numbers, 
			List<string> entryIds, 
			string ruleId, 
			string targetBillTypeId, 
			int targetOrgId, 
			string targetFormId, 
			bool isEnableDefaultRule, 
			bool isDraftWhenSaveFail, 
			JObject customParams) {
			FormId = formId;
			Ids = ids;
			Numbers = numbers;
			EntryIds = entryIds;
			RuleId = ruleId;
			TargetBillTypeId = targetBillTypeId;
			TargetOrgId = targetOrgId;
			TargetFormId = targetFormId;
			IsEnableDefaultRule = isEnableDefaultRule;
			IsDraftWhenSaveFail = isDraftWhenSaveFail;
			CustomParams = customParams;
		}

		public PushModel(Build build) {
			FormId = build.FormId;
			Ids = build.Ids;
			Numbers = build.Numbers;
			EntryIds = build.EntryIds;
			RuleId = build.RuleId;
			TargetBillTypeId = build.TargetBillTypeId;
			TargetOrgId = build.TargetOrgId;
			TargetFormId = build.TargetFormId;
			IsEnableDefaultRule = build.IsEnableDefaultRule;
			IsDraftWhenSaveFail = build.IsDraftWhenSaveFail;
			CustomParams = build.CustomParams;
		}



		/// <summary>
		/// 必录，业务对象表单Id
		/// </summary>
		public string FormId { get; private set; }

		/// <summary>
		/// 非必录，单据内码集合，使用内码时必录
		/// </summary>
		public List<string> Ids { get; private set; }

		/// <summary>
		/// 非必录，单据编码集合，使用编码时必录
		/// </summary>
		public List<string> Numbers { get; private set; }

		/// <summary>
		/// 非必录，分录内码集合，分录下推时必录
		/// 按分录下推时，单据内码和编码不需要填,否则按整单下推
		/// </summary>
		public List<string> EntryIds { get; private set; }

		/// <summary>
		/// 非必录，转换规则内码
		/// 未启用默认转换规则时，则必录
		/// </summary>
		public string RuleId { get; private set; }

		/// <summary>
		/// 非必录，目标单据类型内码
		/// </summary>
		public string TargetBillTypeId { get; private set; }

		/// <summary>
		/// 非必录，目标组织内码
		/// </summary>
		public int TargetOrgId { get; private set; }

		/// <summary>
		/// 非必录，目标单据FormId
		/// 启用默认转换规则时，则必录
		/// </summary>
		public string TargetFormId { get; private set; }

		/// <summary>
		/// 非必录，是否启用默认转换规则，默认false
		/// </summary>
		public bool IsEnableDefaultRule { get; private set; }

		/// <summary>
		/// 非必录，保存失败时是否暂存
		/// 注：暂存的单据是没有编码的
		/// </summary>
		public bool IsDraftWhenSaveFail { get; private set; }

		/// <summary>
		/// 非必录，自定义参数，字典类型
		/// 格式："{key1:value1,key2:value2,...}"
		/// 注：传到转换插件的操作选项中，平台不会解析里面的值
		/// </summary>
		public JObject CustomParams { get; private set; }

		public class Build {
			public string FormId { get; private set; }

			public Build SetFormId(string formId) {
				FormId = formId;
				return this;
			}

			public List<string> Ids { get; private set; }

			public Build SetIds(List<string> ids) {
				Ids = ids;
				return this;
			}

			public List<string> Numbers { get; private set; }

			public Build SetNumbers(List<string> numbers) {
				Numbers = numbers;
				return this;
			}

			public List<string> EntryIds { get; private set; }

			public Build SetEntryIds(List<string> entryIds) {
				EntryIds = entryIds;
				return this;
			}

			public string RuleId { get; private set; }

			public Build SetRuleId(string ruleId) {
				RuleId = ruleId;
				return this;
			}

			public string TargetBillTypeId { get; private set; }

			public Build SetTargetBillTypeId(string targetBillTypeId) {
				TargetBillTypeId = targetBillTypeId;
				return this;
			}

			public int TargetOrgId { get; private set; }

			public Build SetTargetOrgId(int targetOrgId) {
				TargetOrgId = targetOrgId;
				return this;
			}

			public string TargetFormId { get; private set; }

			public Build SetTargetFormId(string targetFormId) {
				TargetFormId = targetFormId;
				return this;
			}

			public bool IsEnableDefaultRule { get; private set; }

			public Build SetIsEnableDefaultRule(bool isEnableDefaultRule) {
				IsEnableDefaultRule = isEnableDefaultRule;
				return this;
			}

			public bool IsDraftWhenSaveFail { get; private set; }
			public Build SetIsDraftWhenSaveFail(bool isDraftWhenSaveFail) {
				IsDraftWhenSaveFail = isDraftWhenSaveFail;
				return this;
			}

			public JObject CustomParams { get; private set; }
			public Build SetCustomParams(JObject customParams) {
				CustomParams = customParams;
				return this;
			}
		}
	}
}
