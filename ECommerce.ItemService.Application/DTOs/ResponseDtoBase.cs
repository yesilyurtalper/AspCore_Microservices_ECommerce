namespace ECommerce.ItemService.Application.DTOs;

public class ResponseDtoBase 
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public string? ResultCode { get; set; }
    public List<string>? ErrorMessages { get; set; }

    public ResponseDtoBase(bool isSuccess = false, string? message = "",
         string? resultCode = "", List<string>? errorMessages = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        ResultCode = resultCode;
        ErrorMessages = errorMessages;
    }
}
