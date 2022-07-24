namespace TheOmenDen.Shared.JsonApi.Models.Relationships;

public interface IRelationship
{
    /// <summary>
    /// A collection that provides access to the underlying resources 
    /// </summary>
    /// <value>
    /// <see cref="Link"/>
    /// </value>
    public IEnumerable<Link> Links { get; set; }

    /// <summary>
    /// The relationship's Meta information
    /// </summary>
    /// <value>
    /// <see cref="Metas.Meta"/>
    /// </value>
    public Meta Meta { get; set; }
}
