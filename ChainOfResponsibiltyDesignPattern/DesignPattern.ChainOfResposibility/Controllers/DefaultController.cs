using DesignPattern.ChainOfResposibility.ChainOfResponsibility;
using DesignPattern.ChainOfResposibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResposibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasure = new TreaSurer();
            Employee managerAssistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee areaDirector = new AreaDirector();

            treasure.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);
            treasure.ProcessRequest(model);
            return View();
        }
    }
}
