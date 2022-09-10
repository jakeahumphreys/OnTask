using NTask.Errors.Models;

namespace NTask.Errors;

public static class ErrorBecause
{
    public static Error MissingRequiredValue(string value) => new Error
    {
        Message = $"Please provide a value for '{value}'."
    };
}