using AlertAI.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AlertAI.Api.Tests;

public class IdeasControllerTests : BaseTest
{
    [Fact]
    public void GetIdeas_ReturnsOk()
    {
        // Arrange
        var dbContext = GetInMemoryDbContext();
        var ideasController = new IdeaController(dbContext);

        // Act
        var actionResult = ideasController.GetIdeas();
        var result = actionResult.Result;

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}