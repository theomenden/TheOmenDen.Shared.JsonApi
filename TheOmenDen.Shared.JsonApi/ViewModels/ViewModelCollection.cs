namespace TheOmenDen.Shared.JsonApi.ViewModels;

/// <summary>
/// A collection of <see cref="ViewModel{TData}"/> to be returned as a single response. 
/// <inheritdoc cref="IEnumerable{T}"/>
/// </summary>
/// <typeparam name="T">The underlying data type</typeparam>
public class ViewModelCollection<T> : ViewModel<ICollection<ViewModel<T>>>, IViewModelCollection, IEnumerable<ViewModel<T>>
{
    /// <summary>
    /// Creates a <see cref="ViewModelCollection{T}"/> with an empty collection of data of type <typeparamref name="T"/>
    /// </summary>
    /// <param name="selfUrl"></param>
    public ViewModelCollection(String selfUrl) 
        : base(selfUrl, new Collection<ViewModel<T>>())
    {}

    /// <summary>
    /// Creates a <see cref="ViewModelCollection{T}"/> with the provided <paramref name="data"/> and a self link <paramref name="selfUrl"/>
    /// </summary>
    /// <param name="selfUrl">The provided self reference for the collection</param>
    /// <param name="data">The provided <see cref="ViewModel{TData}"/>s</param>
    public ViewModelCollection(String selfUrl, ICollection<ViewModel<T>> data) 
        : base(selfUrl, data)
    {}

    /// <summary>
    /// Creates a view model collection from the provided <paramref name="data"/>
    /// </summary>
    /// <param name="data"></param>
    /// <returns>A materialized <see cref="ViewModelCollection{T}"/></returns>
    public static ViewModelCollection<T> From(IEnumerable<T> data)
    {
        var vms = data.Select(d => new ViewModel<T>(d));

        var vmc = new ViewModelCollection<T>($"/{typeof(T).Name}",vms.ToArray());

        return vmc;
    }

    /// <summary>
    /// Creates a <see cref="ViewModelCollection{T}"/> from the provided <paramref name="data"/>
    /// </summary>
    /// <param name="data"></param>
    /// <returns>A materialized <see cref="ViewModelCollection{T}"/></returns>
    public static ViewModelCollection<T> From(IEnumerable<ViewModel<T>> data)
    {
        var vmc = new ViewModelCollection<T>($"/{typeof(T).Name}", data.ToArray());

        return vmc;
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
