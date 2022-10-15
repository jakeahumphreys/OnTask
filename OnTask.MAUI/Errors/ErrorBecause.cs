using OnTask.MAUI.Errors.Models;

namespace OnTask.MAUI.Errors;

public static class ErrorBecause
{
    public static Error MissingRequiredValue(string value) => new Error
    {
        Message = $"Please provide a value for '{value}'."
    };

    public static Error RecordByIdNotFound(Guid id) => new Error
    {
        Message = $"A record was not found for id '{id.ToString()}'."
    };
}