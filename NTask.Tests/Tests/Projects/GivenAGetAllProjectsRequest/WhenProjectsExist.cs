using Moq;
using NTask.Data.Models;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication.Projects;
using NUnit.Framework;

namespace NTask.Tests.Tests.Projects.GivenAGetAllProjectsRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenProjectsExist
{
    private Mock<IProjectRepository> _projectRepository;
    private GetAllProjectsResponse _result;
    private Guid _guid;

    [OneTimeSetUp]
    public void Setup()
    {
        _guid = Guid.NewGuid();
        _projectRepository = new Mock<IProjectRepository>();
        _projectRepository.Setup(x => x.GetAll())
            .Returns(new List<ProjectRecord>
            {
                new ProjectRecord
                {
                    Name = "TestProject",
                    Tasks = new List<TaskRecord>(),
                    IsArchived = false,
                    ProjectId = _guid
                }
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
        Assert.That(_result.Projects.First().Value.IsArchived, Is.EqualTo(false));
    }
}