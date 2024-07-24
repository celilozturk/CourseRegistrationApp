using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Enrollments.Commands.Delete;

internal sealed class DeleteEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteEnrollmentCommand, DeleteEnrollmentResponse>
{
    public async Task<DeleteEnrollmentResponse> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
    {
        Enrollment enrollment = await enrollmentRepository.GetByIdAsync(request.Id,cancellationToken);
        if(enrollment is null)
        {
            throw new EnrollmentNotFoundException(request.Id);
        }
        enrollmentRepository.Delete(enrollment);
        unitOfWork.Commmit();
        return new DeleteEnrollmentResponse(request.Id);
    }
}