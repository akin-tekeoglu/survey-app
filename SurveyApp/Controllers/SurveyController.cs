using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models;

namespace SurveyApp.Controllers;


public class SurveyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/survey")]
    public IActionResult Create(Survey survey)
    {
        var questions = survey.Questions.Where(x =>
             !string.IsNullOrWhiteSpace(x.Value)
        ).Select(x =>
            new Question(x.Value, x.Choices.Where(y => !string.IsNullOrWhiteSpace(y)))
        ).ToList();
        var cleanSurvey = new Survey(survey.Title,questions);
        if(TryValidateModel(cleanSurvey))
        {
            return Redirect("/survey");
        }else{
            // TODO redirect with error‰
            return Redirect("/survey");
        }
        
        
    }
}