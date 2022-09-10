using Moq;
using NTask.Data.Models;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models;
using NTask.Data.Services.Models.Communication;
using NUnit.Framework;

namespace NTask.Tests.Projects.GivenACreateProjectRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenANameIsProvided
{
    private Mock<IProjectRepository> _projectRepository;
    private CreateProjectResponse _result;

    [OneTimeSetUp]
    public void Setup()
    {
        _projectRepository = new Mock<IProjectRepository>();
        var subject = new ProjectService(_projectRepository.Object);

        _result = subject.CreateProject(new CreateProjectRequest
        {
            Name = "TestProjectName"
        });
    }
    
    [Test]
    public void ThenNoErrorsAreReturned()
    {
        Assert.That(_result.HasError, Is.False);
        Assert.That(_result.Errors, Has.Count.EqualTo(0));
    }

    [Test]
    public void ThenTheDataIsPassedToTheRepository()
    {
        _projectRepository.Verify(x => x.Create(It.Is<ProjectRecord>(y => 
            y.IsArchived == false &&
            y.Name == "TestProjectName" &&
            y.Tasks.Count == 0)), Times.Once);
    }
}