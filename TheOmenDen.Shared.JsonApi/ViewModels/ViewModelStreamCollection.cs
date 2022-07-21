namespace TheOmenDen.Shared.JsonApi.ViewModels;
/// <summary>
/// A streamable collection of <see cref="ViewModel{TData}"/>s. 
/// <inheritdoc cref="IAsyncEnumerable{T}"/>
/// </summary>
/// <typeparam name="T">The underlying data type</typeparam>
public class ViewModelStreamCollection<T> : ViewModel<IAsyncEnumerable<ViewModel<T>>>, IAsyncEnumerable<ViewModel<T>>
{
    public IAsyncEnumerator<ViewModel<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return Data.Value.GetAsyncEnumerator(cancellationToken);
    }

    public ViewModelStreamCollection(string selfUrl) 
        : base(selfUrl)
    {
    }

    public ViewModelStreamCollection(string selfUrl, IAsyncEnumerable<ViewModel<T>> data) 
        : base(selfUrl, data)
    {
    }
}
