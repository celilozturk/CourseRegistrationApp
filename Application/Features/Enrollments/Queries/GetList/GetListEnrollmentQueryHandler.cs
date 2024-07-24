using Application.Common;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Enrollments.Queries.GetList;

internal sealed class GetListEnrollmentQueryHandler(IEnrollmentRepository enrollmentRepository,IMapper mapper) : IRequestHandler<GetListEnrollmentQuery, GetListResponse<GetListEnrollmentItemDto>>
{
    public async Task<GetListResponse<GetListEnrollmentItemDto>> Handle(GetListEnrollmentQuery request, CancellationToken cancellationToken)
    {
        var enrollments =mapper.Map<List<GetListEnrollmentItemDto>>(await enrollmentRepository.GetAllAsync());
     
        return new GetListResponse<GetListEnrollmentItemDto> { Items = enrollments };        
    }
}
