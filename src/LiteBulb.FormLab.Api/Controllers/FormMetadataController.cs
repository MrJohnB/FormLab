using Microsoft.AspNetCore.Mvc;

namespace LiteBulb.FormLab.Api.Controllers;
public class FormMetadataController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
