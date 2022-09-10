using NTask.Errors.Models;

namespace NTask.Data.Services.Models;

public class ResponseBase
{
    public List<Error> Errors { get; set; }
    public bool HasError => Errors.Any();

    public ResponseBase WithError(Error error)
    {
        return new ResponseBase
        {
            Errors =
            {
                error
            }
        };
    }
}