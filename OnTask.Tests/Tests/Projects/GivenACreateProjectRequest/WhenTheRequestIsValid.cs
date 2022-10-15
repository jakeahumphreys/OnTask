using Moq;
using NUnit.Framework;
using OnTask.Data.Models;
using OnTask.Data.Repositories;
using OnTask.Data.Services;
using OnTask.Data.Services.Models.Communication.Projects;

namespace OnTask.Tests.Tests.Projects.GivenACreateProjectRequest;

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