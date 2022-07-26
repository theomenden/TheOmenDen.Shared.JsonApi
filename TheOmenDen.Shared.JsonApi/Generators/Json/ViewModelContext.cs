﻿namespace TheOmenDen.Shared.JsonApi.Generators.Json;

/// <summary>
/// Provides the basis for JSON Source/Serialization Generators
/// </summary>
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = true)]
[JsonSerializable(typeof(IViewModel))]
[JsonSerializable(typeof(IEnumerable<IViewModel>))]
[JsonSerializable(typeof(IEnumerable<ViewModel<IViewModel>>))]
[JsonSerializable(typeof(ViewModel<IEnumerable<ViewModel<IViewModel>>>))]
public partial class ViewModelContext : JsonSerializerContext
{}
