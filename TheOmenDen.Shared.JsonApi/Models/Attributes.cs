namespace TheOmenDen.Shared.JsonApi.Models;
[Serializable]
public class Attributes : Dictionary<String, JsonElement>
{
    public static Attributes<T> Create<T>(T data)
    {
        return new(data);
    }
}

[Serializable]
[JsonSerializable(typeof(Attributes))]
public class Attributes<T> : Attributes
{
    public Attributes(T data)
    {
        foreach (var property in data!.GetType().GetProperties())
        {
            var propertyValue = property.GetValue(data);

            var serializedPropertyValue = JsonSerializer.SerializeToElement(propertyValue);

            Add(property.Name, serializedPropertyValue);
        }
    }
}