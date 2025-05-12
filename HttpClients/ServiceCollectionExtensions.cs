using Microsoft.Extensions.DependencyInjection;

namespace HttpClients;

public static class ServiceCollectionExtensions
{
    private const string DefaultHttpClientName = "Library.HttpClient";

    // Register department http client
    public static void RegisterDepartmentsHttpClient(this IServiceCollection services, SystemHttpClientData systemHttpClientData)
    {
        services.RegisterHttpClient<IDepartmentsHttpClient, DepartmentsHttpClient>(
            systemHttpClientData,
            systemHttpClientData.HttpClientName ?? DefaultHttpClientName,
            httpClient => new DepartmentsHttpClient(httpClient));
    }

    // Register Faculties http client
    public static void RegisterFacultiesHttpClient(this IServiceCollection services, SystemHttpClientData systemHttpClientData)
    {
        services.RegisterHttpClient<IFacultiesHttpClient, FacultiesHttpClient>(
            systemHttpClientData,
            systemHttpClientData.HttpClientName ?? DefaultHttpClientName,
            httpClient => new FacultiesHttpClient(httpClient));
    }


    // Register Groups http client
    public static void RegisterGroupsHttpClient(this IServiceCollection services, SystemHttpClientData systemHttpClientData)
    {
        services.RegisterHttpClient<IGroupsHttpClient, GroupsHttpClient>(
            systemHttpClientData,
            systemHttpClientData.HttpClientName ?? DefaultHttpClientName,
            httpClient => new GroupsHttpClient(httpClient));
    }

    // Register Students http client
    public static void RegisterStudentsHttpClient(this IServiceCollection services, SystemHttpClientData systemHttpClientData)
    {
        services.RegisterHttpClient<IStudentsHttpClient, StudentsHttpClient>(
            systemHttpClientData,
            systemHttpClientData.HttpClientName ?? DefaultHttpClientName,
            httpClient => new StudentsHttpClient(httpClient));
    }
   

    public static void RegisterHttpClient<TInterface, TImplementation>(
        this IServiceCollection services,
        SystemHttpClientData systemHttpClientData,
        string name,
        Func<HttpClient, TImplementation> func)
        where TInterface : class
        where TImplementation : TInterface
    {
        HttpClientRegistrator.RegisterHttpClient<TInterface, TImplementation>(services, systemHttpClientData, name, func);
    }
}