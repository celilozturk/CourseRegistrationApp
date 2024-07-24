﻿using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Enrollments.Commands.Create;

internal sealed class CreateEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateEnrollmentCommand, CreateEnrollmentResponse>
{
    public async Task<CreateEnrollmentResponse> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
     
        var enrollment = mapper.Map<Enrollment>(request);
        await enrollmentRepository.CreateAsync(enrollment,cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return mapper.Map<CreateEnrollmentResponse>(enrollment);
    }
}
