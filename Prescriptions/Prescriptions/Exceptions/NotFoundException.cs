namespace Prescriptions.Exceptions;

public class NotFoundException(string message) : Exception
{
    public override string Message { get; } = message;
}