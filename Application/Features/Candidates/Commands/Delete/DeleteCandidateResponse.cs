namespace Application.Features.Candidates.Commands.Delete;

public class DeleteCandidateResponse
{
    public string message { get; set; }

    public DeleteCandidateResponse()
    {
        message = $"Course item was deleted successfully";

    }
    public DeleteCandidateResponse(int id)
    {
        message = $"Item Id:{id} course was deleted successfully";
    }
}