using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using MediatR;

namespace Application.Features.Enrollments.Queries.GetById;

internal sealed class GetByIdEnrollmentQueryHandler(IEnrollmentRepository enrollmentRepository,IMapper mapper) : IRequestHandler<GetByIdEnrollmentQuery, GetByIdEnrollmentResponse>
{
    public async Task<GetByIdEnrollmentResponse> Handle(GetByIdEnrollmentQuery request, CancellationToken cancellationToken)
    {
       var enrollment= await enrollmentRepository.GetByIdWithCourseAndCandidate(request.Id);
        if (enrollment is null)
        {
            throw new EnrollmentNotFoundException(request.Id);
        }
        return mapper.Map<GetByIdEnrollmentResponse>(enrollment);
    }
}
