using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models;

public record Survey(
    [param:Required]
    string Title,
    [param:MaxLength(10, ErrorMessage ="You can't have more than ten questions")]
    [param:MinLength(1,ErrorMessage ="You should add at least one question")]
    List<Question> Questions
);

public record Question(
    [param: Required] string Value,
    [param: MaxLength(5, ErrorMessage = "You can't have more than five choices for signel question")]
    [param: MinLength(1, ErrorMessage = "You should add at least one choice for every question that you entered")]
    List<string> Choices
);