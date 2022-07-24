namespace TheOmenDen.Shared.JsonApi.Models;
/// <summary>
/// Provides a safer approach to unique ids 
/// </summary>
/// <param name="Id">The UUID for an entity</param>
public record EntityId(Guid Id)
{
    public sealed override string ToString()
    {
        return Id.ToString();
    }
};

/// <summary>
/// Generic wrapper for <see cref="EntityId"/> 
/// <inheritdoc cref="EntityId"/>
/// </summary>
/// <typeparam name="T">The underlying type</typeparam>
public record EntityId<T>() : EntityId(Guid.NewGuid())
{
    /// <summary>
    /// The type of the entity that we are working with
    /// </summary>
    /// <value>
    /// Used for application/logic purposes, but not for serialization
    /// </value>
    [JsonIgnore]
    public Type EntityType { get; } = typeof(T);
}