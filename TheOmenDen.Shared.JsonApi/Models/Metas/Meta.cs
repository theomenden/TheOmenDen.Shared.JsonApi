namespace TheOmenDen.Shared.JsonApi.Models.Metas;
/// <summary>
/// Can contain information that may not normally be readily available about a particular type 
/// <inheritdoc cref="Dictionary{TKey, TValue}"/>
/// </summary>
public class Meta : Dictionary<String, JsonObject>
{
}