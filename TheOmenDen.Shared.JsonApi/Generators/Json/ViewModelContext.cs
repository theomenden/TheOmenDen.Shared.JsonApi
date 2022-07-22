namespace TheOmenDen.Shared.JsonApi.Generators.Json;


//[JsonSerializable(typeof(IViewModel))]
//[JsonSerializable(typeof(ViewModel<>))]
//[JsonSerializable(typeof(ViewModelCollection<>))]
//[JsonSerializable(typeof(ViewModelStreamCollection<>))]
////[JsonSerializable(typeof(Data<>))]
////[JsonSerializable(typeof(Models.JsonApi))]
////[JsonSerializable(typeof(Link))]
////[JsonSerializable(typeof(IEnumerable<Link>))]
////[JsonSerializable(typeof(IEnumerable<Error>))]
////[JsonSerializable(typeof(Error))]
////[JsonSerializable(typeof(Meta))]
////[JsonSerializable(typeof(Relationship))]
////[JsonSerializable(typeof(Relationship<>))]
////[JsonSerializable(typeof(Dictionary<String, Relationship>))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Serialization, WriteIndented = true)]
[JsonSerializable(typeof(IViewModel))]
internal partial class ViewModelContext : JsonSerializerContext
{
}
