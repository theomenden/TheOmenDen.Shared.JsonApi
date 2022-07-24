using TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;

namespace TheOmenDen.Shared.JsonApi.Interfaces.Includes;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TData"></typeparam>
public interface ICanInclude<TData>
{

    /// <summary>
    /// Adds a <see cref="Relationship"/> to the <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <typeparam name="TIncluded">The type of the <see cref="Relationship"/> to add</typeparam>
    /// <param name="relationshipKey">The key used to define the relationship</param>
    /// <param name="relationshipToInclude">The entity to base the relationship from</param>
    /// <returns>The builder instance to allow for further chaining</returns>
    ICanInclude<TData> AddRelationship<TIncluded>(String relationshipKey, TIncluded relationshipToInclude);

    /// <summary>
    /// Adds a <see cref="Link"/> to an established <see cref="Relationship"/>
    /// </summary>
    /// <typeparam name="TIncluded">The underlying type in the relationship</typeparam>
    /// <param name="relationshipKey">The relationship's key</param>
    /// <param name="link">The link we want to add</param>
    /// <returns>The builder instance to allow for further chaining</returns>
    ICanInclude<TData> WithLink<TIncluded>(String relationshipKey, RelationLink link);

    /// <summary>
    /// Adds a <see cref="Link"/> to an established <see cref="Relationship"/>
    /// </summary>
    /// <typeparam name="TIncluded">The underlying type in the relationship</typeparam>
    /// <param name="relationshipKey">The relationship's key</param>
    /// <param name="link">The link we want to add</param>
    /// <returns>The builder instance to allow for further chaining</returns>
    ICanInclude<TData> WithLink<TIncluded>(String relationshipKey, Link link);

    /// <summary>
    /// Adds a new <see cref="Link"/> to a relationship with the supplied <paramref name="name"/> and <paramref name="href"/>
    /// </summary>
    /// <typeparam name="TIncluded">The underlying type in the <see cref="Relationship{TData}"/></typeparam>
    /// <param name="relationshipKey">The relationship's key</param>
    /// <param name="name">The <see cref="Link"/>'s name</param>
    /// <param name="href">The <see cref="Link"/>'s url</param>
    /// <returns>The builder instance to allow for further chaining</returns>
    ICanInclude<TData> WithLink<TIncluded>(String relationshipKey, String name, String href);

    /// <summary>
    /// Adds a <see cref="Link"/> to an established <see cref="Relationship"/>
    /// </summary>
    /// <typeparam name="TIncluded">The underlying type in the relationship</typeparam>
    /// <param name="relationshipKey">The relationship's key</param>
    /// <param name="link">The link we want to add</param>
    /// <returns>The builder instance to allow for further chaining</returns>
    ICanInclude<TData> WithSelfLink<TIncluded>(String relationshipKey);

    /// <summary>
    /// Allows for adding a <see cref="IViewModel"/> of the <typeparamref name="TIncluded"/> data to the parent <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <typeparam name="TIncluded">The type of <see cref="Relationship"/> to be included</typeparam>
    /// <param name="included">The data that we're adding to the view model</param>
    /// <returns>The builder instance to allow for further chaining</returns>
    ICanAddDetailsToAViewModel<TData> Include<TIncluded>(TIncluded included);
}

