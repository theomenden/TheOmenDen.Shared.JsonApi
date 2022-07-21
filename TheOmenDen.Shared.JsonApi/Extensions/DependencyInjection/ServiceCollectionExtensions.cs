namespace TheOmenDen.Shared.JsonApi.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers our <see cref="ValidateModelStateActionFilter"/> within the application
    /// </summary>
    /// <param name="services">The provided service collection</param>
    /// <returns>The service collection for further chaining</returns>
    public static IServiceCollection AddJsonApiFilters(this IServiceCollection services)
    {
        services
            .AddMvc(options => options.Filters.Add(typeof(ValidateModelStateActionFilter)));
        return services;
    }
}

