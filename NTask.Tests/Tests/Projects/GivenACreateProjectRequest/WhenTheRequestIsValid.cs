using Moq;
using NTask.Data.Models;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication.Projects;
using NUnit.Framework;

namespace NTask.Tests.Tests.Projects.GivenACreateProjectRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenTheRequestIsValid
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
            Name = "TestProjectName",
            Description = "TestDescription"
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
            y.Description == "TestDescription" &&
            y.Tasks.Count == 0)), Times.Once);
    }
}