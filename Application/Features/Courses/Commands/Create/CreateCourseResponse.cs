namespace Application.Features.Courses.Commands.Create;

public class CreateCourseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalPaticipants { get; set; }
    public DateTime CreatedDate { get; set; }
}