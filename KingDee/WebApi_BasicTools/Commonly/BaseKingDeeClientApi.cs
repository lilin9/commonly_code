using System.Collections.Generic;
using Commonly.CommonUtils;
using Commonly.Models;
using Kingdee.BOS;
using Kingdee.BOS.WebApi.FormService;

namespace Commonly {
	/// <summary>
	/// 金蝶本地客户端的WebApi访问服务的封装
	/// 这里只存放最基础的调用函数
	/// </summary>
	public class BaseKingDeeClientApi {
		/// <summary>
		/// 表单查询，返回 [{key:value}] 形式的查询结果
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="query"></param>
		/// <param name="errorMessage">错误信息。查询成功返回空值，查询失败，返回错误查询信息。</param>
		/// <returns></returns>
		public List<Dictionary<string, object>> BillQuery(Context ctx, BillQueryModel query, out string errorMessage) {
			//构建查询参数
			var parameters = "{" +
			                 $"\"FormId\":\"{query.FormId}\"," +
			                 $"\"TopRowCount\":{query.TopRowCount}," +
			                 $"\"Limit\":{query.Limit}," +
			                 $"\"StartRow\":{query.StartRow()}," +
			                 $"\"FilterString\":\"{query.FilterString}\"," +
			                 $"\"OrderString\":\"{query.OrderString}\"," +
			                 $"\"FieldKeys\":\"{string.Join(",", query.FieldKeys)}\"" +
			                 "}";

			var result = WebApiServiceCall.BillQuery(ctx, parameters);
			errorMessage = JsonUtils.FindErrorMessage(result);

			return !string.IsNullOrEmpty(errorMessage) ?
				null :
				JsonUtils.Deserialize<List<Dictionary<string, object>>>(JsonUtils.Serialize(result));
		}

		/// <summary>
		/// 查询接口，如果返回失败，就返回泛型的默认值：数值类型返回各自的默认值，引用类型返回 null
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ctx"></param>
		/// <param name="query"></param>
		/// <param name="errorMessage">错误信息。查询成功返回空值，查询失败，返回错误查询信息。</param>
		/// <returns></returns>
		public T ExecuteBillQuery<T>(Context ctx, BillQueryModel query, out string errorMessage) {
			//构建查询参数
			var parameters = "{" +
			                 $"\"FormId\":\"{query.FormId}\"," +
			                 $"\"TopRowCount\":{query.TopRowCount}," +
			                 $"\"Limit\":{query.Limit}," +
			                 $"\"StartRow\":{query.StartRow()}," +
			                 $"\"FilterString\":\"{query.FilterString}\"," +
			                 $"\"OrderString\":\"{query.OrderString}\"," +
			                 $"\"FieldKeys\":\"{string.Join(",", query.FieldKeys)}\"" +
			                 "}";

			var result = WebApiServiceCall.ExecuteBillQuery(ctx, parameters);
			errorMessage = JsonUtils.FindErrorMessage(result);

			return !string.IsNullOrEmpty(errorMessage) ?
				default : JsonUtils.Deserialize<T>(JsonUtils.Serialize(result));
		}

		/// <summary>
		/// 保存和修改接口。如果执行失败，返回泛型的默认值。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ctx"></param>
		/// <param name="model"></param>
		/// <param name="errorMessage">错误信息。查询成功返回空值，查询失败，返回错误保存信息。</param>
		/// <returns></returns>
		public T SaveOne<T>(Context ctx, SaveModel model, out string errorMessage) {
			var needUpDateFields = model.NeedUpdateFields.Count > 0 ?
				$"[{"\"" + string.Join("\",\"", model.NeedUpdateFields) + "\""}]" :
				"[]";
			var needReturnFields = model.NeedReturnFields.Count > 0 ?
				$"[{"\"" + string.Join("\",\"", model.NeedReturnFields) + "\""}]" :
				"[]";
			var theModel = model.TheModel.Count > 0 ? model.TheModel[0] : "{}";

			var parameters = "{" +
			                 $"\"Creator\":\"{model.Creator}\"," +
			                 $"\"NeedUpdateFields\":{needUpDateFields}," +
			                 $"\"IsDeleteEntry\":\"{model.IsDeleteEntry}\"," +
			                 $"\"NeedReturnFields\":{needReturnFields}," +
			                 $"\"IsVerifyBaseDataField\":\"{model.IsVerifyBaseDataField}\"," +
			                 $"\"IsEntryBatchFill\":\"{model.IsEntryBatchFill}\"," +
			                 $"\"InterationFlags\":\"{string.Join(";", model.InteractionFlags)}\"," +
			                 $"\"IgnoreInterationFlag\":\"{model.IgnoreInteractionFlag}\"," +
			                 $"\"IsAutoSubmitAndAudit\":\"{model.IsAutoSubmitAndAudit}\"," +
			                 $"\"IsUserModelInit\":\"{model.IsUserModelInit}\"," +
			                 $"\"Model\":{theModel}" +
			                 "}";

			var result = WebApiServiceCall.Save(ctx, model.FormId, parameters);
			errorMessage = JsonUtils.FindErrorMessage(result);


			return !string.IsNullOrEmpty(errorMessage) ?
				default : JsonUtils.Deserialize<T>(JsonUtils.Serialize(result));
		}

		/// <summary>
		/// 批量保存和修改接口
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ctx"></param>
		/// <param name="model"></param>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public T BatchSave<T>(Context ctx, BatchSaveModel model, out string errorMessage) {
			var needUpDateFields = model.NeedUpdateFields.Count > 0 ?
				$"[{"\"" + string.Join("\",\"", model.NeedUpdateFields) + "\""}]" :
				"[]";
			var needReturnFields = model.NeedReturnFields.Count > 0 ?
				$"[{"\"" + string.Join("\",\"", model.NeedReturnFields) + "\""}]" :
				"[]";
			var theModel = model.TheModel.Count > 0 ? model.TheModel.ToString() : "[]";

			var parameters = "{" +
			                 $"\"NumberSearch\":\"{model.NumberSearch}\"," +
			                 $"\"ValidateFlag\":\"{model.ValidateFlag}\"," +
			                 $"\"IsDeleteEntry\":\"{model.IsDeleteEntry}\"," +
			                 $"\"IsEntryBatchFill\":\"{model.IsEntryBatchFill}\"," +
			                 $"\"NeedUpdateFields\":{needUpDateFields}," +
			                 $"\"NeedReturnFields\":{needReturnFields}," +
			                 $"\"SubSystemId\":\"{model.SubSystemId}\"," +
			                 $"\"InterationFlags\":\"{model.InteractionFlags}\"," +
			                 $"\"Model\":{theModel}," +
			                 $"\"BatchCount\":{model.BatchCount}," +
			                 $"\"IsVerifyBaseDataField\":\"{model.IsVerifyBaseDataField}\"," +
			                 $"\"IsAutoAdjustField\":\"{model.IsAutoAdjustField}\"," +
			                 $"\"IgnoreInterationFlag\":\"{model.IgnoreInteractionFlag}\"," +
			                 $"\"IsControlPrecision\":\"{model.IsControlPrecision}\"," +
			                 $"\"ValidateRepeatJson\":\"{model.ValidateRepeatJson}\"" +
			                 "}";

			var result = WebApiServiceCall.BatchSave(ctx, model.FormId, parameters);
			errorMessage = JsonUtils.FindErrorMessage(result);

			return !string.IsNullOrEmpty(errorMessage) ?
				default : JsonUtils.Deserialize<T>(JsonUtils.Serialize(result));
		}

		/// <summary>
		/// 单据下推接口
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ctx"></param>
		/// <param name="model"></param>
		/// <param name="errMsg"></param>
		/// <returns></returns>
		public T Push<T>(Context ctx, PushModel model, out string errMsg) {
			var customParams = model.CustomParams == null ? "{}" : model.CustomParams.ToString();
			var parameters = "{" +
			                 $"\"Ids\":\"{CommonlyUtils.JoinList(model.Ids, ",")}\"," +
			                 $"\"Numbers\":[{CommonlyUtils.JoinList(model.Numbers, ",", "\"")}]," +
			                 $"\"EntryIds\":\"{CommonlyUtils.JoinList(model.EntryIds, ",")}\"," +
			                 $"\"RuleId\":\"{model.RuleId}\"," +
			                 $"\"TargetBillTypeId\":\"{model.TargetBillTypeId}\"," +
			                 $"\"TargetOrgId\":{model.TargetOrgId}," +
			                 $"\"TargetFormId\":\"{model.TargetFormId}\"," +
			                 $"\"IsEnableDefaultRule\":\"{model.IsEnableDefaultRule}\"," +
			                 $"\"IsDraftWhenSaveFail\":\"{model.IsDraftWhenSaveFail}\"," +
			                 $"\"CustomParams\":{customParams}" +
			                 "}";

			var result = WebApiServiceCall.Push(ctx, model.FormId, parameters);
			errMsg = JsonUtils.FindErrorMessage(result);

			return !string.IsNullOrEmpty(errMsg) ?
				default :
				JsonUtils.Deserialize<T>(JsonUtils.Serialize(result));
		}
	}
}
