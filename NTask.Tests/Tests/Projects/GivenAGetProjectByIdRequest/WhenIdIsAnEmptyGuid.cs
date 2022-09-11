using Moq;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication.Projects;
using NUnit.Framework;

namespace NTask.Tests.Tests.Projects.GivenAGetProjectByIdRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenIdIsAnEmptyGuid
{
    private GetProjectByIdResponse _result;
    private Mock<IProjectRepository> _repository;

    [OneTimeSetUp]
    public void Setup()
    {
        _repository = new Mock<IProjectRepository>();
        var subject = new ProjectService(_repository.Object);
        
        _result = subject.GetProjectById(Guid.Empty);
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
        Assert.That(_result.Errors.First().Message, Is.EqualTo($"Please provide a value for 'Id'."));
    }

    [Test]
    public void ThenTheRepositoryIsNotCalled()
    {
        _repository.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Never);
    }
    
}