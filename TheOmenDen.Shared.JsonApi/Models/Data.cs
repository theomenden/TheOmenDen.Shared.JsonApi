namespace TheOmenDen.Shared.JsonApi.Models;

public record Data(Attributes Attributes, Meta MetaData, String Type)
{
    public static Data<T> Create<T>(T value)
    {
        return new(value);
    }
}

/// <summary>
/// Holds information regarding the data we want to expose in an API ViewModel
/// </summary>
/// <typeparam name="T">The underlying type we're working with</typeparam>
/// <param name="Value">The value we want to serialize into the top-level</param>
public record Data<T>(T Value) : Data(Attributes.Create(Value),new Meta(), typeof(T).Name)
{
    /// <summary>
    /// The preserved entity value, ignored during Json Serialization
    /// </summary>
    /// <value>
    /// The actual value provided by <typeparamref name="T" />
    /// </value>
    [JsonIgnore]
    public T Value { get; } = Value;

    /// <summary>
    /// The attributes belonging to the data present.
    /// </summary>
    /// <value>
    /// A set of KeyValue Pairs where the Key is the property name, and the value is the value of the property
    /// </value>
    [JsonPropertyName("attributes")]
    public Attributes Attributes { get; } = Attributes.Create(Value);

    /// <summary>
    /// A generated Id for the underlying Data
    /// </summary>
    /// <value>
    /// A guid based Identifier for the resource
    /// </value>
    [JsonPropertyName("id")]
    public EntityId<T> Id { get; } = new ();

    /// <summary>
    /// The underlying type
    /// </summary>
    /// <value>
    /// <typeparamref name="T"/>
    /// </value>
    [JsonPropertyName("type")]
    public String Type { get; } = typeof(T).Name;
};

