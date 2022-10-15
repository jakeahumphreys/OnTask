using Moq;
using NUnit.Framework;
using OnTask.Data.Models;
using OnTask.Data.Repositories;
using OnTask.Data.Services;
using OnTask.Data.Services.Models.Communication.Projects;
using OnTask.Tests.TestHelpers.Builders;
using TaskStatus = OnTask.Data.Enums.TaskStatus;

namespace OnTask.Tests.Tests.Projects.GivenAGetAllProjectsRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenProjectsExist
{
    private Mock<IProjectRepository> _projectRepository;
    private GetAllProjectsResponse _result;
    private Guid _guid;
    private DateTime _created;
    private Guid _taskGuid;

    [OneTimeSetUp]
    public void Setup()
    {
        _guid = Guid.NewGuid();
        _taskGuid = Guid.NewGuid();
        _created = DateTime.Now;

        var task = new TaskRecordBuilder()
            .WithId(_taskGuid)
            .WithName("TestTask")
            .WithDescription("TestTaskDesc")
            .WithStatus(TaskStatus.Todo)
            .Build();
        
        var project = new ProjectRecordBuilder()
            .WithId(_guid)
            .WithName("TestProject")
            .WithDescription("Description")
            .WithCreated(_created)
            .WithTask(task)
            .IsArchived(false)
            .Build();
        
        _projectRepository = new Mock<IProjectRepository>();
        _projectRepository.Setup(x => x.GetAll())
            .Returns(new List<ProjectRecord>
            {
                project
            });

        var subject = new ProjectService(_projectRepository.Object);
        _result = subject.GetAllProjects();
    }
    
    [Test]
    public void ThenNoErrorsAreReturned()
    {
        Assert.That(_result.HasError, Is.False);
        Assert.That(_result.Errors, Has.Count.Zero);
    }

    [Test]
    public void ThenTheRepositoryIsCalled()
    {
        _projectRepository.Verify(x => x.GetAll(), Times.Once);
    }

    [Test]
    public void ThenTheResponseIsMappedCorrectly()
    {
        Assert.That(_result.Projects.First().Key, Is.EqualTo(_guid));
        Assert.That(_result.Projects.First().Value.Id, Is.EqualTo(_guid));
        Assert.That(_result.Projects.First().Value.Name, Is.EqualTo("TestProject"));
        Assert.That(_result.Projects.First().Value.Description, Is.EqualTo("Description"));
        Assert.That(_result.Projects.First().Value.Created, Is.EqualTo(_created));
        Assert.That(_result.Projects.First().Value.IsArchived, Is.EqualTo(false));
        
        Assert.That(_result.Projects.First().Value.Tasks.First().Id, Is.EqualTo(_taskGuid));
        Assert.That(_result.Projects.First().Value.Tasks.First().Name, Is.EqualTo("TestTask"));
        Assert.That(_result.Projects.First().Value.Tasks.First().Description, Is.EqualTo("TestTaskDesc"));
        Assert.That(_result.Projects.First().Value.Tasks.First().TaskStatus, Is.EqualTo(TaskStatus.Todo));
        Assert.That(_result.Projects.First().Value.Tasks.First().Activities, Has.Count.Zero);
    }
}