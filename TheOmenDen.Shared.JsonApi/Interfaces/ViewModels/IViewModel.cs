namespace TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;
/// <summary>
/// Contains top-level document structures for the JSONApi Standard
/// </summary>
public interface IViewModel
{
    /// <summary>
    /// The data object present in the top level document
    /// </summary>
    [JsonPropertyName("data")]
    Data UntypedData { get; }

    /// <summary>
    /// Any errors that have been returned
    /// </summary>
    [JsonPropertyName("errors")]
    IEnumerable<Error> Errors { get; }
    
    /// <summary>
    /// The meta data for the top level document
    /// </summary>
    [JsonPropertyName("meta")]
    Meta MetaData { get; }

    /// <summary>
    /// The underlying type in the top level document
    /// </summary>
    /// <remarks>
    /// Not mapped in the constructed ViewModel
    /// </remarks>
    [JsonIgnore]
    String Type { get; }
    
    /// <summary>
    /// The current JSON Api standard
    /// </summary>
    [JsonPropertyName("jsonapi")]
    Models.JsonApi JsonApi { get; }

    /// <summary>
    /// A collection of Resource indicators
    /// </summary>
    [JsonPropertyName("links")]
    IEnumerable<Link> Links { get; }
    
    /// <summary>
    /// The underlying relationships in the top level document
    /// </summary>
    [JsonPropertyName("relationships")]
    IDictionary<String, Relationship> Relationships { get; }

    [JsonPropertyName("include")]
    IEnumerable<IViewModel> ViewModels { get; }
}

/// <summary>
/// Generic Wrapper for <see cref="IViewModel"/>
/// <inheritdoc cref="IViewModel"/>
/// </summary>
/// <typeparam name="TData">The underlying type</typeparam>
public interface IViewModel<TData> : IViewModel
{
}