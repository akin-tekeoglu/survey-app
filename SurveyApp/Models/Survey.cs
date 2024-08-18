using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models;

public record Survey(
    [param:Required]
    string Title,
    [param:MaxLength(10)]
    [param:MinLength(1)]
    IEnumerable<Question> Questions
);

public record Question([param:Required]string Value, [param: MaxLength(5)][param: MinLength(1)] IEnumerable<string> Choices);