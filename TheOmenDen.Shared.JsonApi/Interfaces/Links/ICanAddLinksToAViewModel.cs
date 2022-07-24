using TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;

namespace TheOmenDen.Shared.JsonApi.Interfaces.Links;

/// <summary>
/// Defines methods to add various links to a view model
/// </summary>
/// <typeparam name="TData">The underlying view model type</typeparam>
public interface ICanAddLinksToAViewModel<TData>
{
    /// <summary>
    /// Adds a standard self referencing <see cref="Link"/> to the constructing <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <returns>The builder instance for further chaining</returns>
    ICanAddLinksToAViewModel<TData> AddSelfLink();

    /// <summary>
    /// Adds a link to the constructing <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <param name="name">The human readable version of the resource</param>
    /// <param name="href">The resource indicator</param>
    /// <returns>The builder instance for further chaining</returns>
    ICanAddDetailsToAViewModel<TData> AddLink(String name, String href);
}
