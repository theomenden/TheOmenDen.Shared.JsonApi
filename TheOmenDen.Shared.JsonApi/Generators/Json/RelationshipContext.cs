namespace TheOmenDen.Shared.JsonApi.Generators.Json;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, WriteIndented = true)]
[JsonSerializable(typeof(Relationship))]
[JsonSerializable(typeof(IEnumerable<Relationship>))]
internal partial class RelationshipContext: JsonSerializerContext
{
}