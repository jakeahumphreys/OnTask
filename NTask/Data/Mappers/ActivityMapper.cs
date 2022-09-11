using NTask.Data.Models;
using NTask.Data.Services.Models.DTO;

namespace NTask.Data.Mappers;

public static class ActivityMapper
{
    public static ActivityDto FromRecordToDto(ActivityRecord activityRecord)
    {
        return new ActivityDto
        {
            ActivityId = activityRecord.ActivityId,
            Type = activityRecord.Type,
            Contents = activityRecord.Contents
        };
    }
}