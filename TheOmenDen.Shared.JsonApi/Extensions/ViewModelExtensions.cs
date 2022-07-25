namespace TheOmenDen.Shared.JsonApi.Extensions;

public static class ViewModelExtensions
{
    /// <summary>
    /// Transforms the provided <paramref name="data"/> and <paramref name="requestPath"/> into a realized <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <typeparam name="T">The type of data</typeparam>
    /// <param name="data">The data we wish to transform</param>
    /// <param name="requestPath">the self path as a <see cref="Uri"/></param>
    /// <returns>The <see cref="IViewModel"/> instance</returns>
    public static IViewModel GetViewModel<T>(this T data, Uri requestPath)
    where T : class
    {
        return new ViewModel<T>(requestPath.ToString(), data);
    }

    /// <summary>
    /// Transforms the provided <paramref name="data"/> and <paramref name="entityId"/> into a realized <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <typeparam name="T">The type of data</typeparam>
    /// <param name="data">The data we wish to transform</param>
    /// <param name="entityId">The "safe" implementation of an Id - that is used to build the self url</param>
    /// <returns>The <see cref="IViewModel"/> instance</returns>
    public static IViewModel GetViewModel<T>(this T data, EntityId<T> entityId)
    {
        return new ViewModel<T>($"/{entityId.EntityType.Name}/{entityId.Id}",data);
    }
}

