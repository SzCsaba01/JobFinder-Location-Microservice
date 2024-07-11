using Location.Data.Access;
using Location.Data.Contracts;
using Location.Services.Business;
using Location.Services.Contracts;


namespace Location.Microservice.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<ISubRegionRepository, SubRegionRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();

        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<ICityService, CityService>();

        var userMicroserviceUrl = Environment.GetEnvironmentVariable("USER_MICROSERVICE_URL") ?? "http://user-microservice";
        var jobMicroserviceUrl = Environment.GetEnvironmentVariable("JOB_MICROSERVICE_URL") ?? "http://job-microservice";

        services.AddCors(options =>
        {
            options.AddPolicy("Origins", policy =>
            {
                policy.WithOrigins(userMicroserviceUrl).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                policy.WithOrigins(jobMicroserviceUrl).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
        });

        return services;
    }
}
