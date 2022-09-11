using Moq;
using NTask.Data.Models;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication.Projects;
using NTask.Tests.TestHelpers.Builders;
using NUnit.Framework;

namespace NTask.Tests.Tests.Projects.GivenAGetAllProjectsRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenProjectsExist
{
    private Mock<IProjectRepository> _projectRepository;
    private GetAllProjectsResponse _result;
    private Guid _guid;
    private DateTime _created;

    [OneTimeSetUp]
    public void Setup()
    {
        _guid = Guid.NewGuid();
        _created = DateTime.Now;
        
        var project = new ProjectRecordBuilder()
            .WithId(_guid)
            .WithName("TestProject")
            .WithDescription("Description")
            .WithCreated(_created)
            .WithTasks(new List<TaskRecord>())
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
    }
}