namespace TheOmenDen.Shared.JsonApi.Models.Links;
/// <summary>
/// A container for information relative to a <see cref="Relationships.Relationship"/>
/// </summary>
/// <param name="Name">The title of the resource</param>
/// <param name="Href">The actual resource path</param>
/// <param name="DescribedBy">The location for where the resource is described</param>
/// <param name="Type">The type of the relation</param>
/// <param name="Meta">Meta information for the link</param>
public record RelationLink(String Name, String Href, String DescribedBy, Type Type, Meta Meta) 
    : Link(Name, Href);

