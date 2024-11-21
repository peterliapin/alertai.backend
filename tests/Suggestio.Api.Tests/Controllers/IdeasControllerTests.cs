using Suggestio.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Suggestio.Api.Tests;

public class IdeasControllerTests : BaseTest
{
    [Fact]
    public void GetIdeas_ReturnsOk()
    {
        // Arrange
        var dbContext = GetInMemoryDbContext();
        var ideasController = new IdeasController(dbContext);

        // Act
        var actionResult = ideasController.GetIdeas();
        var result = actionResult.Result;

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}