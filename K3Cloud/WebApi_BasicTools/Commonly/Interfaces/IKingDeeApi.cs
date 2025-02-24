namespace Commonly.Interfaces {
    /// <summary>
    /// 金蝶 WebAPI 集合
    /// </summary>
    public interface IKingDeeApi: IBaseService {
        /// <summary>
        /// 身份验证接口
        /// </summary>
        /// <param name="userName">用户登录名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        bool Authentication(string userName, string password);

        /// <summary>
        /// 登录验证接口带踢人功能
        /// </summary>
        /// <param name="userName">用户登陆名</param>
        /// <param name="password">密码</param>
        /// <param name="isKickOff">是否踢人，true:相同客户端会相互踢人</param>
        /// <returns></returns>
        JObject Authentication(string userName, string password, bool isKickOff);

        /// <summary>
        /// 请求表单数据
        /// </summary>
        /// <param name="formId">表单Id</param>
        /// <param name="data">
        /// 数据包，Number表示单据编号或者基础资料编码，Id为主键
        /// CreateOrgId为创建组织Id。格式参考：
        /// "{\"CreateOrgId\":0,\"Id\":0,\"Number\":\"SVINV00000003\"}"
        /// </param>
        /// <returns></returns>
        JObject FindFormDataList(string formId, string data);

        /// <summary>
        /// 表单数据查询接口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject FindFormDataList(string data);

        /// <summary>
        /// 简单账表查询接口
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject FindSystemReportList(string formId, string data);

        /// <summary>
        /// 保存表单数据接口
        /// </summary>
        /// <param name="formId">表单Id</param>
        /// <param name="data">数据包</param>
        /// <returns></returns>
        JObject SaveFormData(string formId, string data);

        /// <summary>
        /// 暂存表单数据接口
        /// </summary>
        /// <param name="formId">表单Id</param>
        /// <param name="data">数据包</param>
        /// <returns></returns>
        JObject TempSaveFormData(string formId, string data);

        /// <summary>
        /// 批量保存表单数据
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject SaveFormDataList(string formId, string data);

        /// <summary>
        /// 提交表单数据接口
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject SubmitFormData(string formId, string data);

        /// <summary>
        /// 审核表单数据接口
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject AuditFormData(string formId, string data);

        /// <summary>
        /// 工作流审批
        /// </summary>
        /// <param name="data"></param>
        void AuditWorkflow(string data);

        /// <summary>
        /// 反审核表单数据
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject CounterAuditFormData(string formId, string data);

        /// <summary>
        /// 删除表单数据接口
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject DeleteFormData(string formId, string data);

        /// <summary>
        /// 分配表单数据
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject AllocationFormData(string formId, string data);

        /// <summary>
        /// 下推接口
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject PushForm(string formId, string data);

        /// <summary>
        /// 分组保存
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject GroupSave(string formId, string data);

        /// <summary>
        /// 弹性域保存
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject ElasticDomainSave(string formId, string data);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="data"></param>
        void SenderMessage(string data);

        /// <summary>
        /// 登出接口，当前请求会话的退出
        /// </summary>
        /// <returns></returns>
        bool Logout();

        /// <summary>
        /// 通用操作
        /// </summary>
        /// <param name="formId">表单Id</param>
        /// <param name="opNumber">操作编码，字符串类型</param>
        /// <param name="data">
        /// 1.Parameters：参数集合
        /// 2.Numbers：单据编码集合
        /// 3.Ids：单据内码集合
        /// 4.Model：表单数据包
        /// </param>
        /// <returns></returns>
        JObject CommonOperate(string formId, string opNumber, string data);

        /// <summary>
        /// 切换上下文默认组织接口
        /// </summary>
        /// <param name="orgNumber">组织代码</param>
        /// <returns></returns>
        JObject SwitchOrganization(string orgNumber);

        /// <summary>
        /// 附件上传（上传附件并绑定单据）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject UploadAttachFile(string data);

        /// <summary>
        /// 文件上传（不绑定单据）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject Upload(string data);

        /// <summary>
        /// 附件下载
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        JObject DownloadAttachFile(string data);
    }
}
