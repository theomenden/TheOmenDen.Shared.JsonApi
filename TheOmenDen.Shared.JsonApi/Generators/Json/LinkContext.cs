namespace TheOmenDen.Shared.JsonApi.Generators.Json;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, WriteIndented = true)]
[JsonSerializable(typeof(Link))]
[JsonSerializable(typeof(RelationLink))]
[JsonSerializable(typeof(PaginationLink))]
[JsonSerializable(typeof(IEnumerable<Link>))]
[JsonSerializable(typeof(IEnumerable<RelationLink>))]
[JsonSerializable(typeof(IEnumerable<PaginationLink>))]
internal partial class LinkContext : JsonSerializerContext
{
}
