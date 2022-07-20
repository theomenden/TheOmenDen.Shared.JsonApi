namespace TheOmenDen.Shared.JsonApi.Models.Relationships;
#nullable disable
/// <summary>
/// Defines a relationship between resources
/// </summary>
public class Relationship
{
    /// <summary>
    /// Creates a relationship for the provided type <typeparamref name="TData"/>
    /// </summary>
    /// <typeparam name="TData">The underlying data type</typeparam>
    /// <param name="data">The supplied data</param>
    /// <returns>A new relationship</returns>
    public static Relationship<TData> Create<TData>(TData data)
    {
        return new()
        {
            Data = data
        };
    }

    /// <summary>
    /// A collection that provides access to the underlying resources 
    /// </summary>
    /// <value>
    /// <see cref="Link"/>
    /// </value>
    public IEnumerable<Link> Links { get; set; } = new List<Link>(2);

    /// <summary>
    /// The relationship's Meta information
    /// </summary>
    /// <value>
    /// <see cref="Metas.Meta"/>
    /// </value>
    public Meta Meta { get; set; }
}

/// <summary>
/// <inheritdoc cref="Relationship"/>
/// </summary>
/// <typeparam name="TData">The underlying data encompassed by the relationship</typeparam>
public class Relationship<TData>
{
    /// <summary>
    /// Underlying information for a relationship that allows a client to issue a single request as opposed to many
    /// </summary>
    public TData Data { get; set; }
}
