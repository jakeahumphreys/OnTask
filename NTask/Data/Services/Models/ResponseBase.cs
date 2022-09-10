using NTask.Errors.Models;

namespace NTask.Data.Services.Models;

public class ResponseBase
{
    public List<Error> Errors { get; set; }
    public bool HasError => Errors.Any();

    public T WithError<T>(Error error) where T: ResponseBase
    {
        Errors.Add(error);
        return (T) this;
    }
}