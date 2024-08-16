using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.Controllers;

public class SurveyController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
}