namespace TheOmenDen.Shared.JsonApi.Interfaces.Collections;

/// <summary>
/// Defines methods to create a <see cref="ViewModelCollection{TData}"/>
/// </summary>
/// <typeparam name="TData">The underlying type</typeparam>
public interface ICanCreateAViewModelCollection<TData>: ICanAddDetailsToAViewModelCollection<TData>
{
    /// <summary>
    /// Allows for the creation of a <see cref="ViewModelCollection{T}"/> from the supplied <paramref name="selfUrl"/> and <paramref name="data"/>
    /// </summary>
    /// <param name="selfUrl">The resource indicator for the collection</param>
    /// <param name="data">The collection of <see cref="ViewModel{TData}"/>s</param>
    /// <returns>The builder instance for further chaining</returns>
    ICanAddDetailsToAViewModelCollection<TData> From(String selfUrl, IEnumerable<ViewModel<TData>> data);

    /// <summary>
    /// Allows for the creation of a <see cref="ViewModelCollection{T}"/> from just the selfUrl
    /// </summary>
    /// <param name="selfUrl">The resource indicator for the collection</param>
    /// <returns>The builder instance for further chaining</returns>
    /// <remarks>call <see cref="ICanAddDetailsToAViewModelCollection{TData}.WithViewModels(Func{IEnumerable{ViewModel{TData}}})"/> to add <see cref="ViewModel{TData}"/>s</remarks>
    ICanAddDetailsToAViewModelCollection<TData> From(String selfUrl);
}
