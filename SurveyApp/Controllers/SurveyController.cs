using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models;

namespace SurveyApp.Controllers;


public class SurveyController : Controller
{
    public IActionResult Index()
    {
        var questions=Enumerable.Repeat(new Question("", Enumerable.Repeat("",5).ToList()),10).ToList();
        return View(new Survey("",questions));
    }

    [HttpPost("/survey")]
    public IActionResult Create(Survey survey)
    {
        var questions = survey.Questions.Where(x =>
             !string.IsNullOrWhiteSpace(x.Value)
        ).Select(x =>
            new Question(x.Value, x.Choices.Where(y => !string.IsNullOrWhiteSpace(y)).ToList())
        ).ToList();
        
        var cleanSurvey = new Survey(survey.Title, questions);
        ModelState.Clear();
        if (TryValidateModel(cleanSurvey))
        {
            return Redirect("/survey");
        }
        else
        {
            return View("Index", cleanSurvey);
        }



    }
}