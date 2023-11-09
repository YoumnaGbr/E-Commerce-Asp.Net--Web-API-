using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Repositories.Contract;
using Talabat.Errors;
using Talabat.Helpers;
using Talabat.Repository;

namespace Talabat.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));

            //webApplicationBuilder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            services.AddAutoMapper(typeof(MappingProfile));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                                                         .SelectMany(P => P.Value.Errors)
                                                         .Select(E => E.ErrorMessage)
                                                         .ToArray();
                    var validationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(validationErrorResponse);
                };
            });

            return services;
        }
    }
}
