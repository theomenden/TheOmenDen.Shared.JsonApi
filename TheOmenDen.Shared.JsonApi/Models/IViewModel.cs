namespace TheOmenDen.Shared.JsonApi.Models;
/// <summary>
/// Contains top-level document structures for the JSONApi Standard
/// </summary>
internal interface IViewModel
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("links")]
    public IEnumerable<Link> Links { get; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error> Errors { get; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("relationships")]
    public IDictionary<String, Relationship> Relationships { get; }

    public Meta MetaData { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public JsonApi JsonApi { get; }
}