using ErrorOr;
using FluentValidation.Results;

namespace Threads.BuildingBlock.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : base("One or more validation failures has occurred.")
            => Errors = failures
                .Distinct()
                .Select(failure => Error.Validation(failure.ErrorCode, failure.ErrorMessage))
                .ToList();

        public IReadOnlyCollection<Error> Errors { get; }
    }
}
