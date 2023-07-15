namespace ECommerce.ItemService.Application.DTOs;

public class ResponseDto<T> : ResponseDtoBase where T : class
{
    public T? Data { get; set; }

    public ResponseDto(bool isSuccess = false, string? message = "",
        T? data = null, string? resultCode = "", List<string>? errorMessages = null) :
        base(isSuccess,message,resultCode,errorMessages)
    {
        Data = data;
    }
}
