using OnTask.MAUI.Errors.Models;

namespace OnTask.MAUI.Data.Services.Models.Communication;

public class ResponseBase
{
    public List<Error> Errors { get; set; }
    public bool HasError => Errors.Any();

    public ResponseBase()
    {
        Errors = new List<Error>();
    }

    public T WithError<T>(Error error) where T: ResponseBase
    {
        Errors.Add(error);
        return (T) this;
    }
}