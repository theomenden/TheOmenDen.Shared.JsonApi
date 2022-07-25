namespace TheOmenDen.Shared.JsonApi.Interfaces.Collections;

/// <summary>
/// Defines methods that add various details to a <see cref="ViewModelCollection{T}"/>
/// </summary>
/// <typeparam name="TData">The underlying data type for the collection</typeparam>
public interface ICanAddDetailsToAViewModelCollection<TData>: ICanAddLinksToAViewModelCollection<TData>
{
    /// <summary>
    /// Allows for adding links to the <see cref="ViewModelCollection{T}"/>
    /// </summary>
    /// <returns>The builder for additional chaining</returns>
    ICanAddDetailsToAViewModelCollection<TData> WithLinks();

    /// <summary>
    /// Allows the definition of a collection of <see cref="ViewModel{TData}"/> to be passed in.
    /// </summary>
    /// <param name="data">The function we wish to pass in</param>
    /// <returns>The builder for further chaining</returns>
    ICanAddDetailsToAViewModelCollection<TData> WithViewModels(Func<IEnumerable<ViewModel<TData>>> data);

    /// <summary>
    /// Creates the fully realized <see cref="ViewModel{TData}"/>
    /// </summary>
    /// <returns><see cref="ViewModel{TData}"/></returns>
    ViewModelCollection<TData> Build();
}
