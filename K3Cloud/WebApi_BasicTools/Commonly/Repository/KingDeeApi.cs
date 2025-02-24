namespace Commonly.Repository {
    public class KingDeeApi: IKingDeeApi {
        //语言Id
        private const int LanguageId = 2052;
        //帐套Id
        private readonly string _fDataCenterId;
        //接口客户端
        private readonly ApiClient _client;

        protected KingDeeApi() {
            //获取连接字符串
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            //获取网站信息
            var webUrl = config.GetConnectionString("KingdeeK3CloudWebUrl");
            //获取帐套Id
            _fDataCenterId = config["FDataCenterId"];
            //获取api客户端
            _client = new ApiClient(webUrl);
        }
        
        public void Execute() {
        }

        public bool Authentication(string userName, string password) {
             return _client.Login(_fDataCenterId, userName, password, LanguageId);
        }

        public virtual JObject Authentication(string userName, string password, bool isKickOff) {
            var result = _client.ValidateLogin2(_fDataCenterId, userName, password, isKickOff, LanguageId);
            return SerializationUtil.JsonToJObject(result);
        }

        public virtual JObject FindFormDataList(string formId, string data) {
            var result = _client.Execute<string>(formId, new object[]{ data });
            return SerializationUtil.JsonToJObject(result);
        }

        public virtual JObject FindFormDataList(string data) {
            throw new NotImplementedException();
        }

        public virtual JObject FindSystemReportList(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject SaveFormData(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject TempSaveFormData(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject SaveFormDataList(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject SubmitFormData(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject AuditFormData(string formId, string data) {
            throw new NotImplementedException();
        }

        public void AuditWorkflow(string data) {
            throw new NotImplementedException();
        }

        public virtual JObject CounterAuditFormData(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject DeleteFormData(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject AllocationFormData(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject PushForm(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject GroupSave(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject ElasticDomainSave(string formId, string data) {
            throw new NotImplementedException();
        }

        public virtual void SenderMessage(string data) {
            throw new NotImplementedException();
        }

        public virtual bool Logout() {
            throw new NotImplementedException();
        }

        public virtual JObject CommonOperate(string formId, string opNumber, string data) {
            throw new NotImplementedException();
        }

        public virtual JObject SwitchOrganization(string orgNumber) {
            throw new NotImplementedException();
        }

        public virtual JObject UploadAttachFile(string data) {
            throw new NotImplementedException();
        }

        public virtual JObject Upload(string data) {
            throw new NotImplementedException();
        }

        public virtual JObject DownloadAttachFile(string data) {
            throw new NotImplementedException();
        }
    }
}
