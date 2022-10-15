using OnTask.Data.Models;
using TaskStatus = OnTask.Data.Enums.TaskStatus;

namespace OnTask.Tests.TestHelpers.Builders;

public class TaskRecordBuilder
{
    private readonly TaskRecord _taskRecord;

    public TaskRecordBuilder()
    {
        _taskRecord = new TaskRecord();
    }

    public TaskRecordBuilder WithId(Guid id)
    {
        _taskRecord.TaskId = id;
        return this;
    }

    public TaskRecordBuilder WithName(string name)
    {
        _taskRecord.Name = name;
        return this;
    }

    public TaskRecordBuilder WithDescription(string description)
    {
        _taskRecord.Description = description;
        return this;
    }

    public TaskRecordBuilder WitDueDate(DateTime dueDate)
    {
        _taskRecord.DueDate = dueDate;
        return this;
    }

    public TaskRecordBuilder WithStatus(TaskStatus taskStatus)
    {
        _taskRecord.Status = taskStatus;
        return this;
    }

    public TaskRecordBuilder WithActivity(ActivityRecord activityRecord)
    {
        _taskRecord.ActivityRecords.Add(activityRecord);
        return this;
    }

    public TaskRecord Build()
    {
        return _taskRecord;
    }
}