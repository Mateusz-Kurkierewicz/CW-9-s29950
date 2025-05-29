namespace Prescriptions.Exceptions;

public class BadRequestException(string message) : Exception
{
    public override string Message { get; } = message;
}