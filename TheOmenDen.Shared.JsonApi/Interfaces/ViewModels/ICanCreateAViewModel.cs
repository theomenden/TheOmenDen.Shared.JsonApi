namespace TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;
/// <summary>
/// Defines methods to create view models
/// </summary>
/// <typeparam name="TData">The underlying view model type</typeparam>
public interface ICanCreateAViewModel<TData> : ICanAddDetailsToAViewModel<TData>
{
    /// <summary>
    /// Creates a view model from the supplied <typeparamref name="TData"/>
    /// </summary>
    /// <param name="data">The underlying information to begin building a view model</param>
    /// <returns>The builder instance for further chaining</returns>
    ICanAddDetailsToAViewModel<TData> FromData(TData data);

    /// <summary>
    /// Creates a view model, with a pregenerated "Self" link
    /// </summary>
    /// <param name="selfUrl">The resource location</param>
    /// <param name="data">The underlying information to begin building a view model</param>
    /// <returns>The builder instance for further chaining</returns>
    ICanAddDetailsToAViewModel<TData> FromData(String selfUrl, TData data);

}

