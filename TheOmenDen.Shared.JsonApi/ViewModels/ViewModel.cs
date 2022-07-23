namespace TheOmenDen.Shared.JsonApi.ViewModels;
#nullable disable
/// <summary>
/// <inheritdoc cref="IViewModel"/>
/// </summary>
/// <typeparam name="TData">The type of underlying data supplied into the view model</typeparam>
public class ViewModel<TData>: IViewModel
{
    #region Private Fields
    private const string SelfLinkName = "self";

    private Data<TData> _data;

    private Meta _meta;

    private Dictionary<String, Relationship> _relationships;

    private readonly List<Link> _links;

    private List<Error> _errors;
    #endregion
    #region Constructors
    public ViewModel(string selfUrl)
    {
        if (selfUrl is null)
        {
            throw new ArgumentNullException(nameof(selfUrl));
        }

        _links = new()
        {
            new (SelfLinkName,  selfUrl)
        };
        _meta = new();
    }

    public ViewModel(string selfUrl, TData data)
        : this(selfUrl)
    {
        _data = new (data);
    }

    public ViewModel(string selfUrl, Meta metaData, TData data)
    : this(selfUrl)
    {
        _meta = metaData;
        _data = new(data);
    }
    #endregion
    #region Properties
    [JsonPropertyName("links")]
    public IEnumerable<Link> Links => _links ?? Enumerable.Empty<Link>();

    [JsonPropertyName("errors")]
    public IEnumerable<Error> Errors => _errors ?? Enumerable.Empty<Error>();

    [JsonPropertyName("relationships")]
    public IDictionary<String, Relationship> Relationships => _relationships ?? new Dictionary<string, Relationship>();

    public Attributes Attributes => _data.Attributes;

    public String Type => _data.Type;

    [JsonPropertyName("data")]
    public Data<TData> Data
    {
        get => _data;
        set => SetData(value);
    }

    [JsonPropertyName("meta")]
    public Meta MetaData
    {
        get => _meta;
        set => SetMetaData(value);
    }

    [JsonPropertyName("jsonapi")] 
    public Models.JsonApi JsonApi { get; } = new();
    #endregion
    #region Public Methods
    public Error AddError(Guid referenceId, Source source, Int32 statusCode, String title, String details)
    {
        EnsureDataHasNotBeenSet();

        EnsureErrorsCollectionIsNotNull();

        var errorDetailsLinks = new[] { new Link(SelfLinkName, $"/errors/{statusCode}") };

        var error = new Error(referenceId, source, statusCode, title, details, errorDetailsLinks);

        _errors!.Add(error);

        return error;
    }

    public Link AddLink(string name, string href)
    {
        var link = new Link(name, href);

        _links!.Add(link);

        return link;
    }

    public Link? GetLink(string name) => 
        Links.SingleOrDefault(c => c.Name.Equals(name));
    #endregion
    #region Private Methods
    private void EnsureDataHasNotBeenSet()
    {
        if (_data is not null)
        {
            throw new InvalidOperationException(Resource.ViewModelCannotAddError);
        }
    }

    private void EnsureErrorsCollectionIsNotNull()
    {
        _errors ??= new(1);
    }

    private void EnsureErrorsHasNotBeenSet()
    {
        if (_errors is not null)
        {
            throw new InvalidOperationException(Resource.ViewModelCannotSetDataProperty);
        }
    }

    private void EnsureRelationshipsAreNotNull()
    {
        _relationships ??= new(1);
    }

    private void SetData(Data<TData> data)
    {
        EnsureErrorsHasNotBeenSet();

        _data = data;
    }
    
    private void SetMetaData(Meta metaData)
    {
        _meta = metaData;
    }
    #endregion
}