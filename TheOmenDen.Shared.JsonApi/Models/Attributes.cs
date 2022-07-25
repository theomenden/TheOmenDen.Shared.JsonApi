namespace TheOmenDen.Shared.JsonApi.Models;
public class Attributes : Dictionary<String, JsonElement>
{
    public static Attributes<T> Create<T>(T data)
    {
        return new(data);
    }
}

public class Attributes<T> : Attributes
{
    public Attributes(T data)
    {
        if (data is null)
        {
            return;
        }

        foreach (var property in data.GetType().GetProperties())
        {
            var propertyValue = property.GetValue(data);

            var serializedPropertyValue = JsonSerializer.SerializeToElement(propertyValue);

            Add(property.Name, serializedPropertyValue);
        }
    }
}