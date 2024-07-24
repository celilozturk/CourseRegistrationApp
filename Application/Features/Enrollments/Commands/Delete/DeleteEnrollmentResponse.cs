namespace Application.Features.Enrollments.Commands.Delete;

public class DeleteEnrollmentResponse
{
    public string message { get; set; }

    public DeleteEnrollmentResponse()
    {
        message = $"Course item was deleted successfully";

    }
    public DeleteEnrollmentResponse(int id)
    {
        message = $"Item Id:{id} course was deleted successfully";
    }
}