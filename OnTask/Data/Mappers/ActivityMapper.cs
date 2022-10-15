using OnTask.Data.Models;
using OnTask.Data.Services.Models.DTO;

namespace OnTask.Data.Mappers;

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