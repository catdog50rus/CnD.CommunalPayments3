namespace CnD.CommunalPayments3.Back.Api.Models.Base.Response;

public abstract class BaseResponse
{
    public bool IsSuccess => ErrorCode == 0;

    public string? ErrorMessage { get; set; }

    public int ErrorCode { get; init; } = 0;
    
    public virtual ResponseResult ErrorResponseResult(string message)
    {
        return new ResponseResult
        {
            ErrorCode = 1,
            ErrorMessage = message,
        };
    }
}