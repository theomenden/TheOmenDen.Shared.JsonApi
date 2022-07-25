namespace TheOmenDen.Shared.JsonApi.Interfaces.Collections;
/// <summary>
/// Marker interface for JSON Contexts source generation
/// </summary>
public interface IViewModelCollection: IViewModel<ICollection<IViewModel>>
{
}

/// <summary>
/// Marker interface for JSON Contexts source generation
/// </summary>
public interface IStreamableViewModelCollection : IViewModel<IAsyncEnumerable<IViewModel>>
{
}
