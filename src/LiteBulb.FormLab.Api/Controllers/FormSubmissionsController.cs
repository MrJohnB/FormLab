using Microsoft.AspNetCore.Mvc;

namespace LiteBulb.FormLab.Api.Controllers;
public class FormSubmissionsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
