using OnTask.MAUI.Data.Models;
using OnTask.MAUI.Data.Services.Models.DTO;

namespace OnTask.MAUI.Data.Mappers;

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