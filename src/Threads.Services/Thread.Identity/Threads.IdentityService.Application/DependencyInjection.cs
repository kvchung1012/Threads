using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Thread.Contract.IdentityService;
using Threads.BuildingBlock.Application.Pipelines;

namespace Threads.IdentityService.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddValidatorsFromAssemblyContaining(typeof(IThreadContractIdentityServiceAssemblyMarker));

            services.AddAutoMapper(typeof(DependencyInjection));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TimeMeasuringBehaviour<,>));
            return services;
        }
    }
}
