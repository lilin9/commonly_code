// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
namespace Commonly.Constants {
	/// <summary>
	/// 这里用于存放全局使用的标识字面量
	/// </summary>
	public enum GlobalConstants {
		#region 字段标识

		//序号 标识
		Seq,
		//单据头Id 标识
		FId,Id,
		//明细列表Id
		FEntryId, EntryId,
		//批号 标识
		Lot, Lot_Text, FLot, Lot_Id, FLot_Text,
		//物料编码Id 标识
		MaterialId, FMaterialId, MaterialId_Id, MaterialId_Text,
		//实发数量 标识
		ActualQty, FActualQty,
		//加工单单价 标识
		F_ZVVE_JGDDJJ,
		//物料总成本 标识
		F_MaterialTotalCost,
		//物料成本单价 标识
		F_MaterialCostPrice,
		//产品成本单价 标识
		F_ProductCostPrice,
		//单据编号 标识
		BillNo,FBillNo,
		//分子字段 标识
		F_Numerator,
		//分母字段 标识
		F_Denominator,
		//生产套数 标识
		F_ProductionSetsNumber,
		//剩余生产套数
		F_RestCost,
		//领料套数 标识
		F_GetSets,
		//实发数量 标识
		FRealQty,RealQty,
		//申请数量 标识
		AppQty, FAppQty,
		//调拨数量 标识
		Qty, FQty, FTranslateQty,
		//应发数量
		FMustQty,
		//未领数量
		F_NoGetNumber,
		//物料单位换算表 单位 标识
		FCurrentUnitId,
		//物料单位换算表 基本单位 标识
		FDestUnitId,
		//物料单位换算表 换算关系分母 标识
		FConvertDenominator,
		//物料单位换算表 换算关系分子 标识
		FConvertNumerator,
		//数据状态 标识
		FDocumentStatus,
		//单位 标识
		UnitID, UnitId_Id,
		//Bom用量系数 标识
		F_BomAmountParameter,
		//仓库唯一Id标识
		StockId, FStockId, 
		//调出仓库 标识
		SrcStockId_Id,
		//即时库存-库存量
		FBaseQty,
		//单据类型标识
		BillTypeID, BillType,
		//主库存单位实发数量
		StockActualQty,
		//主库存基本单位数量
		BaseStockActualQty,
		//基本单位库存实收数量
		BaseRealQty,
		//基本单位实发数量
		BaseActualQty,
		//库存单位实收数量
		StockRealQty,
		//基本单位生产实收数量
		BasePrdRealQty,
		//源单编号
		SrcBillNo,
		//订单编号
		MoId, MoBillNo, F_OrderNo, F_ProductionOrderNumber,
		//单据状态
		DocumentStatus,
		//单位换算系数
		FUnitConversionFactor,
		//汇率
		FExchangeRate,
		//采购订单价格
		FTaxNetPrice,
		//币种
		FSettleCurrId,FSettleCurrText,
		//采购单位
		FPriceUnitId,FPriceUnit_Text,
		//已入库数量
		F_QuantityInStock, F_QuantityStock,
		//领料状态
		F_MaterialRequisition,
		//实收数量之和
		F_SumActualQty,
		//供应商物料编码
		F_SupplierMaterialNo,
		//齐套量
		F_SetsNumber,
		//最小齐套量
		F_MinSetsNumber,
		//价税合计-本位币
		AllAmount_LC, FAllAmount_LC,
		//采购订单价格
		F_CurrencyConvertPrice,
        //计价数量
        PriceUnitQty, FPriceUnitQty,

        #endregion

        #region 控件标识

        //生产加工单文本框 标识
        F_ProduceProcessNo,
		//明细表格 标识
		Entity, FEntity, FBillEntry, InStockEntry, POOrderEntry, FPOOrderEntry, InvInitDetail,
        //调拨领料单明细表格
        TransferDirectEntry,
		//库存批号查询按钮
		QueryInventoryLotBtn, tbQueryStock,
        //下推生产入库单按钮 标识
        tbPushInStorage,
		//批号查询 按钮
		tbQueryLot,
		//订单追溯按钮
		tbOrderRetrospect,
		//订单追溯动态表单
		ZVVE_OrderRetrospect,

		#endregion

		#region 数据库表标识

		//采购入库单表 标识
		STK_InStock,
		//生产加工单表 标识
		PRD_PickMtrl,
		//物料单位换算表
		BD_MATERIALUNITCONVERT,
		//仓库信息表
		BD_STOCK,
		//即时库存
		STK_Inventory,
		//生产入库单
		PRD_INSTOCK,
		//生产订单
		PRD_MO,
		//生产用料清单表
		PRD_PPBOM,
		//收料通知单
		PUR_ReceiveBill,
		//委外订单
		SUB_SUBREQORDER,
		//其他入库单
		STK_MISCELLANEOUS,
		//采购订单
		PUR_PurchaseOrder

		#endregion
	}
}
