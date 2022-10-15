using OnTask.Data.Enums;
using OnTask.Data.Models;

namespace OnTask.Tests.TestHelpers.Builders;

public class ActivityRecordBuilder
{
    private readonly ActivityRecord _activityRecord;

    public ActivityRecordBuilder()
    {
        _activityRecord = new ActivityRecord();
    }

    public ActivityRecordBuilder WithId(Guid id)
    {
        _activityRecord.ActivityId = id;
        return this;
    }

    public ActivityRecordBuilder WithType(ActivityType type)
    {
        _activityRecord.Type = type;
        return this;
    }

    public ActivityRecordBuilder WithContents(string contents)
    {
        _activityRecord.Contents = contents;
        return this;
    }

    public ActivityRecord Build()
    {
        return _activityRecord;
    }
}