using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Commonly.Models {
	/// <summary>
	/// 修改接口的参数模型
	/// 注意：
	/// 表体信息必须填写明细表体的主键，如果不填写，将会删除源单的表体，
	/// 而没有主键的数据会视为新增，有明细主键的视为更新。
	/// </summary>
	public class SaveModel {
		private SaveModel() { }

		public SaveModel(string formId, string creator, List<string> needUpdateFields, bool isDeleteEntry, List<string> needReturnFields, bool isVerifyBaseDataField, bool isEntryBatchFill, bool isUserModelInit, List<string> interactionFlags, bool ignoreInteractionFlag, bool isAutoSubmitAndAudit, JArray theModel) {
			FormId = formId;
			Creator = creator;
			NeedUpdateFields = needUpdateFields;
			IsDeleteEntry = isDeleteEntry;
			NeedReturnFields = needReturnFields;
			IsVerifyBaseDataField = isVerifyBaseDataField;
			IsEntryBatchFill = isEntryBatchFill;
			InteractionFlags = interactionFlags;
			IgnoreInteractionFlag = ignoreInteractionFlag;
			IsAutoSubmitAndAudit = isAutoSubmitAndAudit;
			TheModel = theModel;
			IsUserModelInit = isUserModelInit;
		}

		public SaveModel(Build build) {
			FormId = build.FormId;
			Creator = build.Creator;
			NeedUpdateFields = build.NeedUpdateFields;
			IsDeleteEntry = build.IsDeleteEntry;
			NeedReturnFields = build.NeedReturnFields;
			IsVerifyBaseDataField = build.IsVerifyBaseDataField;
			IsEntryBatchFill = build.IsEntryBatchFill;
			InteractionFlags = build.InteractionFlags;
			IgnoreInteractionFlag = build.IgnoreInteractionFlag;
			IsAutoSubmitAndAudit = build.IsAutoSubmitAndAudit;
			TheModel = build.TheModel;
			IsUserModelInit = build.IsUserModelInit;
		}

		public SaveModel(string formId, string creator, List<string> needUpdateFields, JArray theModel) {
			FormId = formId;
			Creator = creator;
			NeedUpdateFields = needUpdateFields;
			TheModel = theModel;
		}

		public SaveModel(string formId, List<string> needUpdateFields, JArray theModel) {
			FormId = formId;
			NeedUpdateFields = needUpdateFields;
			TheModel = theModel;
		}

		/// <summary>
		/// 必须，表单唯一标识
		/// </summary>
		public string FormId { get; private set; }

		/// <summary>
		/// 非必须，创建人
		/// </summary>
		public string Creator { get; private set; }
		/// <summary>
		/// 非必须，需要更新的字段列表
		/// 如果是更新单据而不是新增一个单据，可以设置这个数据集合，内容为字段标识，使用逗号分隔；
		/// 如果需要更新表体数据，则需要填写表体的标识。
		/// 一般情况下，如果Model中只填写了需要更新的字段信息，没有其他冗余的字段，那么这个参数不需要设置，
		/// 否则其他冗余字段会覆盖ERP中的源单数据。
		/// </summary>
		public List<string> NeedUpdateFields { get; private set; } = new List<string>();

		/// <summary>
		/// 非必须，在修改单据时是否需要删除已经存在的分录
		/// </summary>
		public bool IsDeleteEntry { get; private set; }
		/// <summary>
		/// 非必须，需要返回的字段列表
		/// </summary>
		public List<string> NeedReturnFields { get; private set; } = new List<string>();
		/// <summary>
		/// 非必须，是否需要验证基础资料
		/// </summary>
		public bool IsVerifyBaseDataField { get; private set; }
		/// <summary>
		/// 非必须，是否需要批量填充分录
		/// </summary>
		public bool IsEntryBatchFill { get; private set; }

		/// <summary>
		/// 非必须，是否关闭操作网控限制，默认false
		/// </summary>
		public bool IsUserModelInit { get; private set; }

		/// <summary>
		/// 非必须，交互标志集合，字符串类型，分号分隔
		/// 格式："flag1;flag2;..."
		/// </summary>
		public List<string> InteractionFlags { get; private set; } = new List<string>();

		/// <summary>
		/// 非必须，是否允许忽略交互，布尔类型，默认true
		/// </summary>
		public bool IgnoreInteractionFlag { get; private set; } = true;
		/// <summary>
		/// 非必须，是否自动提交与审核，布尔类型，默认false
		/// 备注：
		/// 启用此参数，保存，提交和审核是在一个事务中。
		/// </summary>
		public bool IsAutoSubmitAndAudit { get; private set; }
		/// <summary>
		/// 必须，格式说明：
		/// 所有字段和实体都是用元素的标识来识别。
		/// 单据头字段直接填写字段标识和数据，子单据头字段需要先申明是子单据头信息，然后再填写其字段信息。
		/// 举例：
		/// {\"FNumber\":\"PRENB001\",
		/// \"FName\":\"牛币\",
		/// \"FCODE\":\"CNYY\",
		/// \"FPRICEDIGITS\":6,
		/// \"FAMOUNTDIGITS\":2,
		/// \"FPRIORITY\":0,
		/// \"FIsShowCSymbol\":true}
		/// </summary>
		public JArray TheModel { get; private set; }

		public class Build {
			public string FormId { get; private set; }
			public Build SetFormId(string formId) {
				FormId = formId;
				return this;
			}

			public string Creator { get; private set; }

			public Build SetCreator(string creator) {
				Creator = creator;
				return this;
			}

			public List<string> NeedUpdateFields { get; private set; } = new List<string>();

			public Build SetNeedUpdateFields(List<string> needUpdateFields) {
				NeedUpdateFields = needUpdateFields;
				return this;
			}

			public bool IsDeleteEntry { get; private set; }
			public Build SetIsDeleteEntry(bool isDeleteEntry) {
				IsDeleteEntry = isDeleteEntry;
				return this;
			}

			public List<string> NeedReturnFields { get; private set; } = new List<string>();
			public Build SetNeedReturnFields(List<string> needReturnFields) {
				NeedReturnFields = needReturnFields;
				return this;
			}

			public bool IsVerifyBaseDataField { get; private set; }
			public Build SetIsVerifyBaseDataField(bool isVerifyBaseDataField) {
				IsVerifyBaseDataField = isVerifyBaseDataField;
				return this;
			}

			public bool IsEntryBatchFill { get; private set; }
			public Build SetIsEntryBatchFill(bool isEntryBatchFill) {
				IsEntryBatchFill = isEntryBatchFill;
				return this;
			}

			public bool IsUserModelInit { get; private set; }

			public Build SetIsUserModelInit(bool isUserModelInit) {
				IsUserModelInit = isUserModelInit;
				return this;
			}

			public List<string> InteractionFlags { get; private set; } = new List<string>();
			public Build SetInteractionFlags(List<string> interactionFlags) {
				InteractionFlags = interactionFlags;
				return this;
			}

			public bool IgnoreInteractionFlag { get; private set; } = true;
			public Build SetIgnoreInteractionFlag(bool ignoreInteractionFlag) {
				IgnoreInteractionFlag = ignoreInteractionFlag;
				return this;
			}

			public bool IsAutoSubmitAndAudit { get; private set; }
			public Build SetIsAutoSubmitAndAudit(bool isAutoSubmitAndAudit) {
				IsAutoSubmitAndAudit = isAutoSubmitAndAudit;
				return this;
			}

			public JArray TheModel { get; private set; }
			public Build SetTheModel(JArray theModel) {
				TheModel = theModel;
				return this;
			}
		}
	}
}
