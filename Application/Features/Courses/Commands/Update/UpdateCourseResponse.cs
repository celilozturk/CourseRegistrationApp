namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalPaticipants { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}