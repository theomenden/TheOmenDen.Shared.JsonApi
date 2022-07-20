namespace TheOmenDen.Shared.JsonApi.Models.Links;
/// <summary>
/// Container for a Link object
/// </summary>
/// <param name="Name">The name of the resource indicator</param>
/// <param name="Href">The actual URL</param>
 public record Link(String Name, String Href);