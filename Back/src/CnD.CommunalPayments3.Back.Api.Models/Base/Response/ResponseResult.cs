namespace CnD.CommunalPayments3.Back.Api.Models.Base.Response;

public class ResponseResult<T> : BaseResponse where T : class, new()
{
    public T Result { get; set; }
}

public class ResponseResult : BaseResponse { }