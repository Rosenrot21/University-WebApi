using FluentValidation.Results;

namespace University.Core.Exceptions;

public class OldValidationException(string message) : DomainException(message)
{
   
    public OldValidationException(List<ValidationFailure> failures) : this("Validation is failed.")
    {
        Failures = failures.AsReadOnly();
    }

    public IReadOnlyCollection<ValidationFailure> Failures { get; }
}
