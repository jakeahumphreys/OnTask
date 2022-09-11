using NTask.Data.Models;

namespace NTask.Tests.TestHelpers.Builders;

public class ProjectRecordBuilder
{
    private ProjectRecord _projectRecord;

    public ProjectRecordBuilder()
    {
        _projectRecord = new ProjectRecord();
    }

    public ProjectRecordBuilder WithId(Guid id)
    {
        _projectRecord.ProjectId = id;
        return this;
    }

    public ProjectRecordBuilder WithName(string name)
    {
        _projectRecord.Name = name;
        return this;
    }

    public ProjectRecordBuilder WithDescription(string description)
    {
        _projectRecord.Description = description;
        return this;
    }

    public ProjectRecordBuilder WithCreated(DateTime created)
    {
        _projectRecord.Created = created;
        return this;
    }

    public ProjectRecordBuilder WithTask(TaskRecord taskRecord)
    {
        _projectRecord.Tasks.Add(taskRecord);
        return this;
    }

    public ProjectRecordBuilder IsArchived(bool isArchived)
    {
        _projectRecord.IsArchived = isArchived;
        return this;
    }

    public ProjectRecord Build()
    {
        return _projectRecord;
    }
}