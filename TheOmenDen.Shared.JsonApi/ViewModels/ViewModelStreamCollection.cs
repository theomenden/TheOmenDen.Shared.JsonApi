namespace TheOmenDen.Shared.JsonApi.ViewModels;
/// <summary>
/// A streamable collection of <see cref="ViewModel{TData}"/>s. 
/// <inheritdoc cref="IAsyncEnumerable{T}"/>
/// </summary>
/// <typeparam name="T">The underlying data type</typeparam>
/// <remarks>Not fully implemented</remarks>
public class ViewModelStreamCollection<T> : ViewModel<IAsyncEnumerable<ViewModel<T>>>, IStreamableViewModelCollection, IAsyncEnumerable<ViewModel<T>>
{
    public IAsyncEnumerator<ViewModel<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return Data.Value.GetAsyncEnumerator(cancellationToken);
    }

    /// <summary>
    /// Creates an empty <see cref="ViewModelStreamCollection{T}"/>
    /// </summary>
    /// <param name="selfUrl">The url for the collection</param>
    public ViewModelStreamCollection(string selfUrl) 
        : base(selfUrl)
    {
    }

    /// <summary>
    /// Creates a <see cref="ViewModelStreamCollection{T}"/> with the provided <paramref name="selfUrl"/> and <paramref name="data"/>
    /// </summary>
    /// <param name="selfUrl">The url for the collection</param>
    /// <param name="data">The underlying data for the collection</param>
    public ViewModelStreamCollection(string selfUrl, IAsyncEnumerable<ViewModel<T>> data) 
        : base(selfUrl, data)
    {
    }
}
