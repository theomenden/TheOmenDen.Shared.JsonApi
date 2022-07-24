using TheOmenDen.Shared.JsonApi.Interfaces.Includes;
using TheOmenDen.Shared.JsonApi.Interfaces.Links;

namespace TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;

/// <summary>
/// Defines methods to build out various details of a view model
/// </summary>
/// <typeparam name="TData">The underlying type of a view model</typeparam>
public interface ICanAddDetailsToAViewModel<TData>
    : ICanAddLinksToAViewModel<TData>
{
    /// <summary>
    /// Adds <see cref="Meta"/>-data to the <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <param name="meta">Additional meta information</param>
    /// <returns>The builder instance to allow for further chaining</returns>
    ICanAddDetailsToAViewModel<TData> WithMeta(Meta meta);

    /// <summary>
    /// Allows for adding various links to the <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <returns>The builder instance to allow for further chaining</returns>
    ICanAddLinksToAViewModel<TData> WithLinks();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    ICanInclude<TData> WithRelatedData();

    /// <summary>
    /// Creates the fully realized <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <returns><see cref="ViewModel{TData}"/></returns>
    ViewModel<TData> Build();
}
