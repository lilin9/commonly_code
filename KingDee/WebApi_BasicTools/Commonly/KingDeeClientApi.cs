using System.Collections.Generic;
using Commonly.Constants;
using Commonly.Models;
using Kingdee.BOS;
using Newtonsoft.Json.Linq;

namespace Commonly {
	/// <summary>
	/// 金蝶本地客户端的WebApi访问服务的封装
	/// 这里只存放 BaseKingDeeClientApi 方法的扩展方法
	/// </summary>
	public class KingDeeClientApi: BaseKingDeeClientApi {
		//通过单例模式来全局调用 KingDeeClientApi
		public static KingDeeClientApi Instance { get; } = new KingDeeClientApi();


		/// <summary>
		/// 查询数据库表单个字段值
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
			string whereValue,
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
			string fieldValue,
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
			string fieldValue,
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
	}
}
