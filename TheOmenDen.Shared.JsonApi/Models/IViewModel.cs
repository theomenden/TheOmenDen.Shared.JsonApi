namespace TheOmenDen.Shared.JsonApi.Models;
/// <summary>
/// Contains top-level document structures for the JSONApi Standard
/// </summary>
public interface IViewModel
{
    /// <summary>
    /// The underlying type in the top level document
    /// </summary>
    /// <remarks>
    /// Not mapped in the constructed ViewModel
    /// </remarks>
    [JsonIgnore]
    String Type { get; }

    /// <summary>
    /// A collection of Resource indicators
    /// </summary>
    [JsonPropertyName("links")]
    IEnumerable<Link> Links { get; }

    /// <summary>
    /// Any errors that have been returned
    /// </summary>
    [JsonPropertyName("errors")]
    IEnumerable<Error> Errors { get; }

    /// <summary>
    /// The underlying relationships in the top level document
    /// </summary>
    [JsonPropertyName("relationships")]
    IDictionary<String, Relationship> Relationships { get; }

    /// <summary>
    /// The meta data for the top level document
    /// </summary>
    [JsonPropertyName("meta")]
    Meta MetaData { get; set; }

    /// <summary>
    /// The current JSON Api standard
    /// </summary>
    [JsonPropertyName("jsonapi")]
    JsonApi JsonApi { get; }


    /// <summary>
    /// The data object present in the top level document
    /// </summary>
    [JsonPropertyName("data")]
    Data UntypedData { get; }
}