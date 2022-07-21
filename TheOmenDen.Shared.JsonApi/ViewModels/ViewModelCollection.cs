using System.Collections;

namespace TheOmenDen.Shared.JsonApi.ViewModels;

/// <summary>
/// A collection of <see cref="ViewModel{TData}"/> to be returned as a single response. 
/// <inheritdoc cref="IEnumerable{T}"/>
/// </summary>
/// <typeparam name="T">The underlying data type</typeparam>
public class ViewModelCollection<T> : ViewModel<ICollection<ViewModel<T>>>, IEnumerable<ViewModel<T>>
{
    public ViewModelCollection(string selfUrl) 
        : base(selfUrl, new Collection<ViewModel<T>>())
    {
    }

    public ViewModelCollection(string selfUrl, ICollection<ViewModel<T>> data) 
        : base(selfUrl, data)
    {
    }

    public IEnumerator<ViewModel<T>> GetEnumerator()
    {
        return Data.Value.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
