using Kanban_AKM.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kanban_AKM.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Privacy_ReturnsViewResult()
    {
        var controller = new HomeController();

        var result = controller.Privacy();

        Assert.IsType<ViewResult>(result);
    }
}
