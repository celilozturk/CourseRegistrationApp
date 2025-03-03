﻿using Application.Services;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.Email.AzureQueueEmailService;
using Infrastructure.Services.Email.AzureQueueStorageEmailFunctionAppService;
using Infrastructure.Services.Email.MailKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"));
        });
        services.AddIdentity<AppUser, AppRole>(action =>
        {
            action.Password.RequiredLength = 5;
            action.Password.RequireUppercase = false;
            action.Password.RequireLowercase = false;
            action.Password.RequireNonAlphanumeric = false;
            action.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICourseRepository, CourseRepository>();  
        services.AddScoped<ICandidateRepository, CandidateRepository>();    
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();  
        services.AddScoped<IJwtProvider,JwtProvider>();
        //services.AddScoped<IEmailService, MailKitEMailService>();

        var connectionString = configuration.GetConnectionString("AzureQueueStorage");
        services.AddSingleton(QueueClient=>AzureQueueClientFactory.CreateQueueClient(connectionString,EQueueName.emails.ToString()));
        services.AddScoped<IEmailService, QueueEmailService>();

        return services;
    }
}
