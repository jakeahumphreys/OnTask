using Moq;
using NTask.Data.Models;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication;
using NTask.Data.Services.Models.Communication.Projects;
using NUnit.Framework;

namespace NTask.Tests.Projects.GivenAGetProjectByIdRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenARecordExists
{
    private GetProjectByIdResponse _result;
    private Mock<IProjectRepository> _repository;

    private Guid _guid;

    [OneTimeSetUp]
    public void Setup()
    {
        _guid = Guid.NewGuid();
        
        _repository = new Mock<IProjectRepository>();
        _repository.Setup(x => x.GetById(It.Is<Guid>(y => y == _guid)))
            .Returns(new ProjectRecord
            {
                Name = "TestRecord",
                Tasks = new List<TaskRecord>(),
                IsArchived = false,
                ProjectId = _guid
            });
        
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
        Assert.That(_result.Project.IsArchived, Is.False);
    }
}