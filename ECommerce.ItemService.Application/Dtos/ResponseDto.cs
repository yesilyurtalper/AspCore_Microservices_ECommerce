namespace ECommerce.ItemService.Application.Dtos;

public class ResponseDto
{
    public bool IsSuccess { get; set; }
    public string DisplayMessage { get; set; } = "";
    public string ResultCode { get; set; } = "";
    public List<string> ErrorMessages { get; set; }
    public object Result { get; set; }
}
