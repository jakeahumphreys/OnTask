using Moq;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication.Projects;
using NUnit.Framework;

namespace NTask.Tests.Tests.Projects.GivenAGetProjectByIdRequest;

[TestFixture]
[Parallelizable]
public sealed class WhenARecordDoesNotExist
{
    private GetProjectByIdResponse _result;
    private Mock<IProjectRepository> _repository;

    private Guid _guid;

    [OneTimeSetUp]
    public void Setup()
    {
        _guid = Guid.NewGuid();
        
        _repository = new Mock<IProjectRepository>();
        
        var subject = new ProjectService(_repository.Object);
        
        _result = subject.GetProjectById(_guid);
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
        Assert.That(_result.Errors.First().Message, Is.EqualTo($"A record was not found for id '{_guid.ToString()}'."));
    }

    [Test]
    public void ThenTheRepositoryIsCalled()
    {
        _repository.Verify(x => x.GetById(It.Is<Guid>(y => y== _guid)), Times.Once);
    }
}