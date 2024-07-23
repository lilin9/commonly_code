namespace webapi {
    public class ResponseResult {
        public bool Success { get; set; }
        public int? Code { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
