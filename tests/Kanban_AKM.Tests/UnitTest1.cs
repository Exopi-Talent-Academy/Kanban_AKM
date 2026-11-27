using Kanban_AKM.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kanban_AKM.Tests;

[TestClass]
public class HomeControllerTests
{
    [TestMethod]
    public void Privacy_ReturnsViewResult()
    {
        var controller = new HomeController();

        var result = controller.Privacy();

        Assert.IsInstanceOfType<ViewResult>(result);
    }
}
