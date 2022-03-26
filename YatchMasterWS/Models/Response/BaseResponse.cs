namespace YatchMasterWS.Models.Response
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public int Response_code { get; set; }
        public object? Data { get; set; }
    }
}
