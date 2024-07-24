using MediatR;

namespace Application.Features.Enrollments.Commands.Delete;
public record DeleteEnrollmentCommand(int Id):IRequest<DeleteEnrollmentResponse>;
