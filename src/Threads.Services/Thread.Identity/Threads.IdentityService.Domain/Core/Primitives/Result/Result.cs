using Threads.IdentityService.Domain.Core.Primitives;

namespace Threads.IdentityService.Domain.Primitives.Result
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess;
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static Result Success() => new(true, Error.None);

        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<TValue> Failure<TValue>(Error error) => new(default!, false, error);

        public static Result<TValue> Create<TValue>(TValue value, Error error)
            where TValue : class
            => value is not null ? Success(value) : Failure<TValue>(error);

        public static Result FirstFailureOrSuccess(Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                {
                    return result;
                }
            }

            return Success();
        }
    }

    /// <summary>
    /// Định nghĩa kết quả có dữ liệu trả về
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class Result<TValue> : Result
    {
        private readonly TValue _value;
        public Result(TValue value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }

        public static implicit operator Result<TValue>(TValue value) => Success(value);

        public TValue Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");
    }
}
