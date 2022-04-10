namespace YatchMasterWS.Models.Request
{
    public class MailRequest
    {
        public string? To_email { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
