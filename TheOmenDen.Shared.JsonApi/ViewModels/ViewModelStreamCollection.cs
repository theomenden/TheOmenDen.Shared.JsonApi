namespace TheOmenDen.Shared.JsonApi.ViewModels;

public class ViewModelStreamCollection<T> : ViewModel<IAsyncEnumerable<ViewModel<T>>>, IAsyncEnumerable<ViewModel<T>>
{

    public IAsyncEnumerator<ViewModel<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
