namespace ResultPatternImplementation
{
    public static class ResultExtension
    {
        public static async Task<T> Match<T>(
            this Result result,
            Func<T> onSuccess,
            Func<Error, T> onFailure)
        {
            return result.IsSuccess ? onSuccess() : onFailure(result.Error);
        }

    }
}
