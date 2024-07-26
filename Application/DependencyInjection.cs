using Application.Behaviors.Logging;
using Application.Behaviors.Validation;
using Application.Features.Applications.Rules;
using Application.Features.Candidates.Rules;
using Application.Features.Courses.Rules;
using Application.Features.Enrollments.Rules;
using Application.Features.Users.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly=Assembly.GetExecutingAssembly();
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));  
        });
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddScoped(typeof(CourseBusinessRules));
        services.AddScoped(typeof(UserBusinessRules));
        services.AddScoped(typeof(CandidateBusinessRules));
        services.AddScoped(typeof(EnrollmentBusinessRules));
        services.AddScoped(typeof(ApplicationBusinessRules));

        //Refactor => service registration for business rules!

        return services;
    }
//    
}
