using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Commonly.Models {
	/// <summary>
	/// 批量保存接口的参数模型
	/// 注意：
	/// 表体信息必须填写明细表体的主键，如果不填写，将会删除源单的表体，
	/// 而没有主键的数据会视为新增，有明细主键的视为更新。
	/// </summary>
	public class BatchSaveModel {
		private BatchSaveModel() { }

		public BatchSaveModel(string formId, bool numberSearch, bool validateFlag, bool isDeleteEntry, bool isEntryBatchFill, List<string> needUpdateFields, List<string> needReturnFields, string subSystemId, string interactionFlags, JArray theModel, int batchCount, bool isVerifyBaseDataField, bool isAutoAdjustField, bool ignoreInteractionFlag, bool isControlPrecision, bool validateRepeatJson) {
			FormId = formId;
			NumberSearch = numberSearch;
			ValidateFlag = validateFlag;
			IsDeleteEntry = isDeleteEntry;
			IsEntryBatchFill = isEntryBatchFill;
			NeedUpdateFields = needUpdateFields;
			NeedReturnFields = needReturnFields;
			SubSystemId = subSystemId;
			InteractionFlags = interactionFlags;
			TheModel = theModel;
			BatchCount = batchCount;
			IsVerifyBaseDataField = isVerifyBaseDataField;
			IsAutoAdjustField = isAutoAdjustField;
			IgnoreInteractionFlag = ignoreInteractionFlag;
			IsControlPrecision = isControlPrecision;
			ValidateRepeatJson = validateRepeatJson;
		}

		public BatchSaveModel(Build build) {
			FormId = build.FormId;
			NumberSearch = build.NumberSearch;
			ValidateFlag = build.ValidateFlag;
			IsDeleteEntry = build.IsDeleteEntry;
			IsEntryBatchFill = build.IsEntryBatchFill;
			NeedUpdateFields = build.NeedUpdateFields;
			NeedReturnFields = build.NeedReturnFields;
			SubSystemId = build.SubSystemId;
			InteractionFlags = build.InteractionFlags;
			TheModel = build.TheModel;
			BatchCount = build.BatchCount;
			IsVerifyBaseDataField = build.IsVerifyBaseDataField;
			IsAutoAdjustField = build.IsAutoAdjustField;
			IgnoreInteractionFlag = build.IgnoreInteractionFlag;
			IsControlPrecision = build.IsControlPrecision;
			ValidateRepeatJson = build.ValidateRepeatJson;
		}



		/// <summary>
		/// 业务对象表单Id，字符串类型（必录）
		/// </summary>
		public string FormId {get; private set; }

		/// <summary>
		/// 是否用编码搜索基础资料，布尔类型，默认true（非必录）
		/// </summary>
		public bool NumberSearch { get; private set; } = true;

		/// <summary>
		/// 是否验证数据合法性标志，布尔类型，默认true（非必录）
		/// 注（设为false时不对数据合法性进行校验）
		/// </summary>
		public bool ValidateFlag { get; private set; } = true;

		/// <summary>
		/// 是否删除已存在的分录，布尔类型，默认true（非必录）
		/// </summary>
		public bool IsDeleteEntry { get; private set; } = true;

		/// <summary>
		/// 是否批量填充分录，默认true（非必录）
		/// </summary>
		public bool IsEntryBatchFill { get; private set; } = true;

		/// <summary>
		/// 需要更新的字段，数组类型，格式：[key1,key2,...] （非必录）
		/// 注（更新字段时Model数据包中必须设置内码，若更新单据体字段还需设置分录内码）
		/// </summary>
		public List<string> NeedUpdateFields { get; private set; }

		/// <summary>
		/// 需返回结果的字段集合，数组类型，格式：[key,entitykey.key,...]（非必录）
		/// 注（返回单据体字段格式：entitykey.key）
		/// </summary>
		public List<string> NeedReturnFields { get; private set; }

		/// <summary>
		/// 表单所在的子系统内码，字符串类型（非必录）
		/// </summary>
		public string SubSystemId { get; private set; }

		/// <summary>
		/// 交互标志集合，字符串类型，分号分隔，格式："flag1;flag2;..."（非必录）
		/// 例如（允许负库存标识：STK_InvCheckResult）
		/// </summary>
		public string InteractionFlags { get; private set; }

		/// <summary>
		/// 表单数据包，JSON类型（必录）
		/// </summary>
		public JArray TheModel { get; private set; }

		/// <summary>
		/// 服务端开启的线程数，整型（非必录）
		/// 注（数据包数应大于此值，否则无效）
		/// </summary>
		public int BatchCount { get; private set; }

		/// <summary>
		/// 是否验证所有的基础资料有效性，布尔类，默认false（非必录）
		/// </summary>
		public bool IsVerifyBaseDataField { get; private set; }

		/// <summary>
		/// 是否自动调整JSON字段顺序，布尔类型，默认false（非必录）
		/// </summary>
		public bool IsAutoAdjustField { get; private set; }

		/// <summary>
		/// 是否允许忽略交互，布尔类型，默认true（非必录）
		/// </summary>
		public bool IgnoreInteractionFlag { get; private set; }

		/// <summary>
		/// 是否控制精度，为true时对金额、单价和数量字段进行精度验证，默认false（非必录）
		/// </summary>
		public bool IsControlPrecision { get; private set; }

		/// <summary>
		/// 校验Json数据包是否重复传入，一旦重复传入，接口调用失败，默认false（非必录）
		/// </summary>
		public bool ValidateRepeatJson { get; private set; }


		public class Build {
			public string FormId { get; private set; }

			public Build SetFormId(string formId) {
				FormId = formId;
				return this;
			}

			public bool NumberSearch { get; private set; } = true;
			public Build SetNumberSearch(bool numberSearch) {
				NumberSearch = numberSearch;
				return this;
			}

			public bool ValidateFlag { get; private set; } = true;
			public Build SetValidateFlag(bool validateFlag) {
				ValidateFlag = validateFlag;
				return this;
			}

			public bool IsDeleteEntry { get; private set; } = true;
			public Build SetIsDeleteEntry(bool isDeleteEntry) {
				IsDeleteEntry = isDeleteEntry;
				return this;
			}

			public bool IsEntryBatchFill { get; private set; } = true;
			public Build SetIsEntryBatchFill(bool isEntryBatchFill) {
				IsEntryBatchFill = isEntryBatchFill;
				return this;
			}

			public List<string> NeedUpdateFields { get; private set; }
			public Build SetNeedUpdateFields(List<string> needUpdateFields) {
				NeedUpdateFields = needUpdateFields;
				return this;
			}

			public List<string> NeedReturnFields { get; private set; }
			public Build SetNeedReturnFields(List<string> needReturnFields) {
				NeedReturnFields = needReturnFields;
				return this;
			}

			public string SubSystemId { get; private set; }
			public Build SetSubSystemId(string subSystemId) {
				SubSystemId = subSystemId;
				return this;
			}

			public string InteractionFlags { get; private set; }
			public Build SetInteractionFlags(string interactionFlags) {
				InteractionFlags = interactionFlags;
				return this;
			}

			public JArray TheModel { get; private set; }
			public Build SetTheModel(JArray theModel) {
				TheModel = theModel;
				return this;
			}

			public int BatchCount { get; private set; }
			public Build SetBatchCount(int batchCount) {
				BatchCount = batchCount;
				return this;
			}

			public bool IsVerifyBaseDataField { get; private set; }
			public Build SetIsVerifyBaseDataField(bool isVerifyBaseDataField) {
				IsVerifyBaseDataField = isVerifyBaseDataField;
				return this;
			}

			public bool IsAutoAdjustField { get; private set; }
			public Build SetIsAutoAdjustField(bool isAutoAdjustField) {
				IsAutoAdjustField = isAutoAdjustField;
				return this;
			}

			public bool IgnoreInteractionFlag { get; private set; }
			public Build SetIgnoreInteractionFlag(bool ignoreInteractionFlag) {
				IgnoreInteractionFlag = ignoreInteractionFlag;
				return this;
			}

			public bool IsControlPrecision { get; private set; }
			public Build SetIsControlPrecision(bool isControlPrecision) {
				IsControlPrecision= isControlPrecision;
				return this;
			}

			public bool ValidateRepeatJson { get; private set; }
			public Build SetValidateRepeatJson(bool validateRepeatJson) {
				ValidateRepeatJson = validateRepeatJson;
				return this;
			}
		}
	}
}
