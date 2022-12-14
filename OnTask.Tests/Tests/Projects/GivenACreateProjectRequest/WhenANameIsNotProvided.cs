using Moq;
using NUnit.Framework;
using OnTask.Data.Models;
using OnTask.Data.Repositories;
using OnTask.Data.Services;
using OnTask.Data.Services.Models.Communication.Projects;

namespace OnTask.Tests.Tests.Projects.GivenACreateProjectRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenANameIsNotProvided
{
    private Mock<IProjectRepository> _projectRepository;
    private CreateProjectResponse _result;

    [OneTimeSetUp]
    public void Setup()
    {
        _projectRepository = new Mock<IProjectRepository>();
        var subject = new ProjectService(_projectRepository.Object);

        _result = subject.CreateProject(new CreateProjectRequest());
    }
    
    [Test]
    public void ThenAnErrorIsReturned()
    {
        Assert.That(_result.HasError, Is.True);
        Assert.That(_result.Errors, Has.Count.EqualTo(1));
    }

    [Test]
    public void ThenTheExpectedErrorIsReturned()
    {
        Assert.That(_result.Errors.First().Message, Is.EqualTo("Please provide a value for 'Name'."));
    }

    [Test]
    public void ThenTheDataIsNotPassedToTheRepository()
    {
        _projectRepository.Verify(x => x.Create(It.IsAny<ProjectRecord>()), Times.Never);
    }
}