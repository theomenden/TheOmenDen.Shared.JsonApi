namespace TheOmenDen.Shared.JsonApi.Generators.Json;
/// <summary>
/// Provides the basis for JSON Source/Serialization Generators
/// </summary>
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = true)]
[JsonSerializable(typeof(IViewModelCollection))]
[JsonSerializable(typeof(IViewModel))]
public partial class ViewModelCollectionContext : JsonSerializerContext
{
}

