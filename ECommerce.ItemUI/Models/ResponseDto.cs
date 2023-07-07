namespace ECommer.ItemUI.Models
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public string DisplayMessage { get; set; } = "";
        public string ResultCode { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
        public object Data { get; set; }
    }
}
