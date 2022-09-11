using Moq;
using NTask.Data.Models;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication.Projects;
using NTask.Tests.TestHelpers.Builders;
using NUnit.Framework;

namespace NTask.Tests.Tests.Projects.GivenAGetProjectByIdRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenARecordExists
{
    private GetProjectByIdResponse _result;
    private Mock<IProjectRepository> _repository;

    private Guid _guid;
    private DateTime _created;

    [OneTimeSetUp]
    public void Setup()
    {
        _guid = Guid.NewGuid();
        _created = DateTime.Now;
        
        var project = new ProjectRecordBuilder()
            .WithId(_guid)
            .WithName("TestRecord")
            .WithDescription("Description")
            .WithCreated(_created)
            .WithTasks(new List<TaskRecord>())
            .IsArchived(false)
            .Build();
        
        _repository = new Mock<IProjectRepository>();
        _repository.Setup(x => x.GetById(It.Is<Guid>(y => y == _guid)))
            .Returns(project);
        
        var subject = new ProjectService(_repository.Object);
        
        _result = subject.GetProjectById(_guid);
    }
    
    [Test]
    public void ThenAnErrorIsNotReturned()
    {
        Assert.That(_result.HasError, Is.False);
        Assert.That(_result.Errors, Has.Count.EqualTo(0));
    }

    [Test]
    public void ThenTheRepositoryIsCalled()
    {
        _repository.Verify(x => x.GetById(It.Is<Guid>(y => y == _guid)), Times.Once);
    }

    [Test]
    public void ThenTheResponseIsMappedCorrectly()
    {
        Assert.That(_result.Project.Id, Is.EqualTo(_guid));
        Assert.That(_result.Project.Name, Is.EqualTo("TestRecord"));
        Assert.That(_result.Project.Description, Is.EqualTo("Description"));
        Assert.That(_result.Project.Created, Is.EqualTo(_created));
        Assert.That(_result.Project.IsArchived, Is.False);
    }
}