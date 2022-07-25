namespace TheOmenDen.Shared.JsonApi.Fluent;
/// <summary>
/// A fluent builder that can generate a <see cref="ViewModelCollectionBuilder{TData}"/>
/// </summary>
/// <typeparam name="TData">The underlying type of the builder</typeparam>
public class ViewModelCollectionBuilder<TData>
    : ICanCreateAViewModelCollection<TData>
{
    private ViewModelCollection<TData> _viewModelCollection;

    /// <summary>
    /// Initializes the builder
    /// </summary>
    /// <returns>The builder for further chaining</returns>
    public static ICanCreateAViewModelCollection<TData> CreateBuilder()
    {
        return new ViewModelCollectionBuilder<TData>();
    }

    public ICanAddDetailsToAViewModelCollection<TData> WithLinks()
    {
        return this;
    }

    public ICanAddDetailsToAViewModelCollection<TData> WithViewModels(Func<IEnumerable<ViewModel<TData>>> data)
    {
        var viewModels = data?.Invoke().ToArray() ?? Array.Empty<ViewModel<TData>>();

        if (!viewModels.Any())
        {
            throw new ArgumentNullException(paramName: nameof(data), message: @"Data supplied was null");
        }

        _viewModelCollection.Data = new(viewModels);


        return this;
    }
    public ViewModelCollection<TData> Build()
    {
        return _viewModelCollection;
    }
    #region Create Collection From methods
    public ICanAddDetailsToAViewModelCollection<TData> From(String selfUrl, IEnumerable<ViewModel<TData>> data)
    {
        _viewModelCollection = new(selfUrl, data.ToArray());
        
        return this;
    }

    public ICanAddDetailsToAViewModelCollection<TData> From(String selfUrl)
    {
        _viewModelCollection = new (selfUrl);

        return this;
    }
    #endregion
    #region Add Links To View Model Collection
    public ICanAddDetailsToAViewModelCollection<TData> AddLink(string name, string href)
    {
        _viewModelCollection.AddLink(name, href);

        return this;
    }

    public ICanAddDetailsToAViewModelCollection<TData> AddLink(Link link)
    {
        _viewModelCollection.AddLink(link);

        return this;
    }

    public ICanAddDetailsToAViewModelCollection<TData> AddLink(PaginationLink link)
    {
        _viewModelCollection.AddLink(link);

        return this;
    }
    #endregion
}

