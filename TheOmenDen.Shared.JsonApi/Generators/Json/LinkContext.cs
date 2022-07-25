namespace TheOmenDen.Shared.JsonApi.Generators.Json;

/// <summary>
/// Provides the basis for JSON Source/Serialization Generators
/// </summary>
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, WriteIndented = true)]
[JsonSerializable(typeof(Link))]
[JsonSerializable(typeof(RelationLink))]
[JsonSerializable(typeof(PaginationLink))]
[JsonSerializable(typeof(IEnumerable<Link>))]
[JsonSerializable(typeof(IEnumerable<RelationLink>))]
[JsonSerializable(typeof(IEnumerable<PaginationLink>))]
public partial class LinkContext : JsonSerializerContext
{
}
