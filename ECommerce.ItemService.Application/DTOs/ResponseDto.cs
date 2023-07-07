namespace ECommerce.ItemService.Application.DTOs;

public class ResponseDto<T> where T : class
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public string? ResultCode { get; set; } 
    public List<string>? ErrorMessages { get; set; }

    public ResponseDto(bool isSuccess = false, string? message = "",
        T? data = null, string? resultCode = "", List<string>? errorMessages = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
        ResultCode = resultCode;
        ErrorMessages = errorMessages;
    }
}
