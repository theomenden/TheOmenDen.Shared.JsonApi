namespace TheOmenDen.Shared.JsonApi.Generators.Json;

/// <summary>
/// Provides the basis for JSON Source/Serialization Generators
/// </summary>
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, WriteIndented = true)]
[JsonSerializable(typeof(Error))]
public partial class ErrorContext : JsonSerializerContext
{
}