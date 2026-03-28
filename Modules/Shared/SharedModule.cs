using ContentApi.Modules.Shared.Services;

namespace ContentApi.Modules.Shared;

public static class SharedModule
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddSingleton<AuthService>();
        return services;
    }
}
