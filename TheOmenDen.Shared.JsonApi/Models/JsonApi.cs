namespace TheOmenDen.Shared.JsonApi.Models;
/// <summary>
/// A top level resource indicating JsonApi standard support level
/// </summary>
/// <param name="Version">The latest version of JsonApi supported</param>
public record JsonApi(String Version = "1.1");
