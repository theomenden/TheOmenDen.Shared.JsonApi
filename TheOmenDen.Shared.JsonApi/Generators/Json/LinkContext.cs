namespace TheOmenDen.Shared.JsonApi.Generators.Json;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, WriteIndented = true)]
[JsonSerializable(typeof(Link))]
[JsonSerializable(typeof(RelationLink))]
[JsonSerializable(typeof(IEnumerable<Link>))]
[JsonSerializable(typeof(IEnumerable<RelationLink>))]
internal partial class LinkContext : JsonSerializerContext
{
}
