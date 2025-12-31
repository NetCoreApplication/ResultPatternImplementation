public class Result<T> : Result
{
    public T? Data { get; }
    public Result(bool isSuccess, Error error, T? data = default) 
     : base(isSuccess, error)
    {
        Data = data;
    }
}

public class Result
{
    public Result(bool isSuccess, Error? error =null)
    {
        IsSuccess = isSuccess;
        Error = error ?? Error.None;
    }

    public bool IsSuccess { get; }
    public Error Error { get; }

    public static Result Success() => new Result(true);

    public static Result Failure(Error error) => new Result(false, error);

    public static Result<T> Success<T>(T data) => new Result<T>(true, Error.None, data);
    public static Result<T> Failure<T>(Error error) => new Result<T>(false, error, default(T));

    public override string ToString()
    {
        return IsSuccess ? "Success" : $"Failure: {Error}";
    }
}