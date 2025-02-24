using Commonly.Constants;
using Commonly.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Commonly.CommonUtils;
using Kingdee.BOS.Orm.DataEntity;
using Context = Kingdee.BOS.Context;

namespace Commonly {
	/// <summary>
	/// 金蝶本地客户端的WebApi访问服务的封装
	/// 这里只存放 BaseKingDeeClientApi 方法的扩展方法
	/// </summary>
	public class KingDeeClientApi: BaseKingDeeClientApi {
		//通过单例模式来全局调用 KingDeeClientApi
		public static KingDeeClientApi Instance { get; } = new KingDeeClientApi();


		/// <summary>
		/// 查询数据库表单个字段值，使用单一条件查询
		/// </summary>
		/// <param name="ctx">context上下文</param>
		/// <param name="formId">单据唯一标识</param>
		/// <param name="whereKey">筛选条件</param>
		/// <param name="whereValue">筛选值</param>
		/// <param name="fieldKey">需要查询的字段</param>
		/// <param name="errorMessage">查询错误信息</param>
		/// <returns></returns>
		public object QuerySingleField(Context ctx, 
			string formId,
			string whereKey,
			object whereValue,
			string fieldKey, 
			out string errorMessage) {
			if (string.IsNullOrEmpty(formId) || string.IsNullOrEmpty(whereKey) || string.IsNullOrEmpty(fieldKey)) {
				errorMessage = "参数formId、whereKey、fieldKey不能为空";
				return null;
			}

			var queryModel = new BillQueryModel(new BillQueryModel.Build()
				.SetFormId(formId)
				.SetFilterString($"{whereKey}='{whereValue}'")
				.SetFieldKeys([fieldKey]));

			var result = BillQuery(ctx, queryModel, out errorMessage);
			if (result == null || result.Count == 0) {
				return null;
			}

			var dicInfo = result[0];
			return dicInfo.TryGetValue(fieldKey, out var value) ? value : null;
		}

		/// <summary>
		/// 查询数据库表单个字段值，可以传入多个查询条件
		/// </summary>
		/// <param name="ctx">context上下文</param>
		/// <param name="formId">单据唯一标识</param>
		/// <param name="filterString">筛选条件，可添加多个</param>
		/// <param name="fieldKey">需要查询的字段</param>
		/// <param name="errorMessage">查询错误信息</param>
		/// <returns></returns>
		public object QuerySingleField(Context ctx, 
			string formId,
			string filterString,
			string fieldKey, 
			out string errorMessage) {
			if (string.IsNullOrEmpty(formId) || string.IsNullOrEmpty(filterString) || string.IsNullOrEmpty(fieldKey)) {
				errorMessage = "参数formId、filterString、fieldKey不能为空";
				return null;
			}

			var queryModel = new BillQueryModel(new BillQueryModel.Build()
				.SetFormId(formId)
				.SetFilterString(filterString)
				.SetFieldKeys([fieldKey]));

			var result = BillQuery(ctx, queryModel, out errorMessage);
			if (result == null || result.Count == 0) {
				return null;
			}

			var dicInfo = result[0];
			return dicInfo.TryGetValue(fieldKey, out var value) ? value : null;
		}

		/// <summary>
		/// 通过单据编号的内码，对单个表单字段进行修改
		/// </summary>
		/// <param name="context">context上下文</param>
		/// <param name="formId">单据唯一标识</param>
		/// <param name="billId">单据编号内码</param>
		/// <param name="fieldName">需要修改的字段名</param>
		/// <param name="fieldValue">需要修改的字段值</param>
		/// <param name="errorMessage">修改错误信息</param>
		public void SaveSingleField(Context context,
			string formId,
			string billId,
			string fieldName,
			object fieldValue,
			out string errorMessage) {
			SaveSingleField(context, 
				formId, 
				GlobalConstants.FId.ToString(), 
				billId, 
				fieldName, 
				fieldValue, 
				out errorMessage);
		}

		/// <summary>
		/// 通过单据编号的内码，对单个表单字段进行修改
		/// </summary>
		/// <param name="context">context上下文</param>
		/// <param name="formId">单据唯一标识</param>
		/// <param name="whereKey">保存条件</param>
		/// <param name="whereVal">条件值</param>
		/// <param name="fieldName">需要修改的字段名</param>
		/// <param name="fieldValue">需要修改的字段值</param>
		/// <param name="errorMessage">修改错误信息</param>
		public void SaveSingleField(Context context,
			string formId,
			string whereKey,
			string whereVal,
			string fieldName,
			object fieldValue,
			out string errorMessage) {
			//需要修改的字段
			var updateValue = new JArray(new JObject(
				new JProperty(whereKey, whereVal),
				new JProperty(fieldName, fieldValue)
			));
			
			var saveModel = new SaveModel(new SaveModel.Build()
				.SetFormId(formId)
				.SetNeedUpdateFields(new List<string> { fieldName })
				.SetTheModel(updateValue)
				.SetIsUserModelInit(true) //取消网控
				.SetIgnoreInteractionFlag(true));

			SaveOne<object>(context, saveModel, out errorMessage);
		}

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="formId">单据标识</param>
        /// <param name="needUpdateFields">需要修改的字段</param>
        /// <param name="entry">需要修改的整个单据体</param>
        /// <param name="errorMessage">错误信息</param>
        public void BatchSave(Context context,
			string formId, 
			List<string> needUpdateFields,
			DynamicObject entry, 
            out string errorMessage) {
            var jObjEntry = JsonUtils.Deserialize<JObject>(JsonUtils.Serialize(entry));
            var dataArray = new JArray { jObjEntry };
            var model = new BatchSaveModel(new BatchSaveModel.Build()
				.SetFormId(formId)
				.SetNeedUpdateFields(needUpdateFields)
			.SetBatchCount(dataArray.Count <= 2 ? 1 : 2)
			.SetTheModel(dataArray));

			Instance.BatchSave<object>(context, model, out errorMessage);
		}

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="formId">单据标识</param>
        /// <param name="needUpdateFields">需要修改的字段</param>
        /// <param name="theModel">单据体数据，需要提供单据内码和分录内码</param>
        /// <param name="errorMessage">错误信息</param>
        public void BatchSave(Context context,
			string formId, 
			List<string> needUpdateFields,
			JArray theModel, 
            out string errorMessage) {
            var model = new BatchSaveModel(new BatchSaveModel.Build()
				.SetFormId(formId)
				.SetNeedUpdateFields(needUpdateFields)
			.SetBatchCount(theModel.Count <= 2 ? 1 : 2)
			.SetTheModel(theModel));

			Instance.BatchSave<object>(context, model, out errorMessage);
		}
	}
}
