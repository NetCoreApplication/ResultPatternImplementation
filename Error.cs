public class Error
{

    private static readonly Error _none = new Error(string.Empty);

    public Error(string message)
    {
        Message = message ?? string.Empty;

    }

    public string Message { get;  }


    public static Error None => _none;


    public static implicit operator Error(string message)
    {
        return new Error(message);
    }

    public static implicit operator string(Error? error)
    {
        return error?.Message ?? string.Empty;
    }
    public override string ToString()
    {
        return Message;
    }
}