namespace TheOmenDen.Shared.JsonApi.Generators.Json;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, WriteIndented = true)]
[JsonSerializable(typeof(IViewModel))]
public partial class ViewModelContext : JsonSerializerContext
{
}
