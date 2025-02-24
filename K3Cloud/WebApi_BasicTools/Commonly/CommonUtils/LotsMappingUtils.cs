using System.Collections.Generic;
using Commonly.Constants;

namespace Commonly.CommonUtils {
	/// <summary>
	/// 批号映射信息工具类
	/// 根据批号前缀去获取对应的表单单据信息
	/// </summary>
	public static class LotsMappingUtils {
		private static readonly Dictionary<string, List<object>> LotMappingInfos;
 
		static LotsMappingUtils() {
			var lotMappingInfos = new Dictionary<string, List<object>> {
				//收料通知单
				{
					"AB-", [
						GlobalConstants.PUR_ReceiveBill.ToString()
					]
				}, 
				//生产加工单
				{
					"HB-", [
						GlobalConstants.PRD_PickMtrl.ToString(),
						GlobalConstants.F_ProductCostPrice.ToString()
					]
				}, 
				//委外订单
				{ 
					"HO-", [
						GlobalConstants.SUB_SUBREQORDER.ToString()
					]
				}, 
				//其他入库单
				{ 
					"HH-", [
						GlobalConstants.STK_MISCELLANEOUS.ToString(),
						GlobalConstants.F_MaterialCostPrice.ToString()
					]
				}
			};

			LotMappingInfos = lotMappingInfos;
		}       
		
		/// <summary>
		/// 传入批号，获取其前缀
		/// </summary>
		/// <param name="lotText"></param>
		/// <returns></returns>
		public static string GetLotTextPrefix(string lotText) {
			return lotText?.Substring(0, lotText.IndexOf('-') + 1);
		}


		/// <summary>
		/// 传入批号前缀，获取对应的表单单据标识
		/// </summary>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static string GetFormId(string prefix) {
			if (string.IsNullOrEmpty(prefix)) {
				return null;
			}

			return LotMappingInfos.TryGetValue(prefix, out var info) ? info[0]?.ToString() : null;
		}

		/// <summary>
		/// 传入批号前缀，获取需要查询的字段标识
		/// </summary>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static string GetFieldKey(string prefix) {
			if (string.IsNullOrEmpty(prefix)) {
				return null;
			}

			return LotMappingInfos.TryGetValue(prefix, out var info) ? info[1]?.ToString() : null;
		}

	}
}
