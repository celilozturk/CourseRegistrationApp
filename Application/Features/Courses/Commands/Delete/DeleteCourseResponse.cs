namespace Application.Features.Courses.Commands.Delete;

public class DeleteCourseResponse
{
    public string message;

    public DeleteCourseResponse()
    {
        message = $"Course item was deleted successfully";

    }
    public DeleteCourseResponse(int id)
    {
      message=  $"Item Id:{id} course was deleted successfully";
    }
}