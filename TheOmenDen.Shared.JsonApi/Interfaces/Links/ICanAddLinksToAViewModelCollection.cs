namespace TheOmenDen.Shared.JsonApi.Interfaces.Links;
/// <summary>
/// Describes methods for a <see cref="Fluent.ViewModelCollectionBuilder{TData}{TData}"/> to add links
/// </summary>
/// <typeparam name="TData">The underlying <see cref="ViewModelCollection{TData}"/> type</typeparam>
public interface ICanAddLinksToAViewModelCollection<TData>
{
    /// <summary>
    /// Adds a link to the constructing <see cref="ViewModelCollection{TData}"/>
    /// </summary>
    /// <param name="name">The human readable version of the resource</param>
    /// <param name="href">The resource indicator</param>
    /// <returns>The builder instance for further chaining</returns>
    ICanAddDetailsToAViewModelCollection<TData> AddLink(String name, String href);

    /// <summary>
    /// Adds a link to the <see cref="ViewModelCollection{T}"/>
    /// </summary>
    /// <param name="link">The url</param>
    /// <returns>The builder instance for further chaining</returns>
    ICanAddDetailsToAViewModelCollection<TData> AddLink(Link link);

    /// <summary>
    /// Adds a <see cref="PaginationLink"/> to the <see cref="ViewModelCollection{T}"/>'s link collection 
    /// </summary>
    /// <param name="link">The paged link</param>
    /// <returns>The builder instance for further chaining</returns>
    ICanAddDetailsToAViewModelCollection<TData> AddLink(PaginationLink link);
}

