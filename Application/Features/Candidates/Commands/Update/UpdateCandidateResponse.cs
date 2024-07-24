namespace Application.Features.Candidates.Commands.Update;

public class UpdateCandidateResponse
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public int Age { get; set; } = default;
    public DateTime CreatedDate { get; set; } = default;
    public DateTime UpdatedDate { get; set; } = default;

}