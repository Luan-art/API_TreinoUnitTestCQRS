using Microsoft.Extensions.DependencyInjection;

using Domain.Commands.v1.CreatePerson;
using Domain.Contracts.v1;
using Domain.Services.v1;
using Domain.Pipes.v1;

using MediatR;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using FluentValidation.AspNetCore;


namespace Domain
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDomainContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddAutoMapper(typeof(Bootstrapper))
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Bootstrapper)))
                .AddScoped<IDomainNotificationService, DomainNotificationServiceHandler>()
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>))
                .AddCommands()
                .AddValidators();
        }

        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<CreatePersonCommandHandler>();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<CreatePersonCommand>, CreatePersonCommandValidator>();
            return services;
        }

    }
}
