using System;
using HttpClients;
using MediatR;
using Microsoft.Extensions.Configuration;
using University.Core.Domain.Students.Common;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using University.Core.Common;
using University.Infrastructure.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Groups.Common;
using University.Infrastructure.Core.Domain.Departments.Common;
using University.Infrastructure.Core.Domain.Faculties.Common;
using University.Infrastructure.Core.Domain.Students.Common;
using University.Infrastructure.Core.Domain.Groups.Common;
using University.Infrastructure.Common;
using University.Infrastructure.Exceptions;
using WebApi.Exceptions;

namespace University.Infrastructure
{
    public static class InfrastructureRegistration
    {

        public static void AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();

            
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IFacultyDepartmentRepository, FacultyDepartmentRepository>();
            services.AddScoped<IDepartmentGroupRepository, DepartmentGroupRepository>();
            services.AddScoped<IGroupStudentRepository, GroupStudentRepository>();



            services.AddScoped<IStudentFirstNameMustBeInRangeChecker, StudentFirstNameMustBeInRangeChecker>();
            services.AddScoped<IGroupNameMustBeUniqueChecker, GroupNameMustBeUniqueChecker>();
            services.AddScoped<IFacultyNameMustBeUniqueChecker, FacultyNameMustBeUniqueChecker>();
            services.AddScoped<IDepartmentNameMustBeUniqueChecker, DepartmentNameMustBeUniqueChecker>();

            // exceptions
            services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
            services.AddSingleton<IExceptionToResponseDeveloperMapper, ExceptionToResponseDeveloperMapper>();
            services.AddTransient<ExceptionHandlerDeveloperMiddleware>();
            services.AddTransient<ExceptionHandlerMiddleware>();

            // consume http clients
            //services.Configure<SystemHttpClientsSettings>(configuration.GetSection(nameof(SystemHttpClientsSettings)));
            //var systemHttpClientsSettings = configuration.GetSection(nameof(SystemHttpClientsSettings)).Get<SystemHttpClientsSettings>()
            //?? throw new AggregateException($"Settings: '{nameof(SystemHttpClientsSettings)}' is not found in configurations.");

            //services.RegisterDepartmentsHttpClient(systemHttpClientsSettings.University);
            //services.RegisterFacultiesHttpClient(systemHttpClientsSettings.University);
            //services.RegisterGroupsHttpClient(systemHttpClientsSettings.University);
            //services.RegisterStudentsHttpClient(systemHttpClientsSettings.University);
            // http clients
            //services.Configure<SystemHttpClientsSettings>(configuration.GetSection(nameof(SystemHttpClientsSettings)));
            //var systemHttpClientsSettings = configuration.GetSection(nameof(SystemHttpClientsSettings)).Get<SystemHttpClientsSettings>()
            //                                ?? throw new AggregateException($"Settings: '{nameof(SystemHttpClientsSettings)}' is not found in configurations.");
            //services.RegisterAuthorsHttpClient(systemHttpClientsSettings.Library);
            //services.RegisterBocksHttpClient(systemHttpClientsSettings.Library);
        }
    }
}
