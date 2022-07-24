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

    private List<Link> _links;

    private List<Error> _errors;
    #endregion
    #region Constructors
    private ViewModel()
    {
    }

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

    public ViewModel(TData data)
    {
        _data = new(data);
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
    public IDictionary<String, Relationship> Relationships => _relationships;

    [JsonIgnore]
    public String Type => _data.Type;

    [JsonIgnore]
    public Data<TData> Data
    {
        get => _data;
        set => SetData(value);
    }

    public Data UntypedData => _data;

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

    public void InitializeLinkCollection()
    {
        _links ??= new List<Link>(5);
    }
    
    public Link AddLink(string name, string href)
    {
        var link = new Link(name, href);

        _links!.Add(link);

        return link;
    }

    public Relationship<TRelation> AddRelationship<TRelation>(String relationKey,TRelation relationData)
    {
        EnsureRelationshipsAreNotNull();

        if(string.IsNullOrWhiteSpace(relationKey))
        {
            relationKey = typeof(TRelation).Name;
        }

        var relationship = Relationship.Create(relationData);

        _relationships.Add(relationKey,relationship);

        return relationship;
    }
    
    public Link GetLink(string name) => 
        Links.SingleOrDefault(c => c.Name.Equals(name));

    public Meta AddMetaData(Meta metaData)
    {
        EnsureMetaDataIsNotNull();

        foreach (var information in metaData)
        {
            _meta.Add(information.Key, information.Value);
        }

        return _meta;
    }
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

    private void EnsureRelationshipsAreNotNull()
    {
        _relationships ??= new();
    }

    private void EnsureErrorsHasNotBeenSet()
    {
        if (_errors is not null)
        {
            throw new InvalidOperationException(Resource.ViewModelCannotSetDataProperty);
        }
    }

    private void EnsureMetaDataIsNotNull()
    {
        _meta ??= new();
    }

    private void SetData(Data<TData> data)
    {
        EnsureErrorsHasNotBeenSet();

        _data = data;
    }
    
    private void SetMetaData(Meta metaData)
    {
        EnsureMetaDataIsNotNull();

        _meta = metaData;
    }
    #endregion
    #region Static Methods
    public static ViewModel<TData> Empty()
    {
        return new();
    }
    #endregion
}