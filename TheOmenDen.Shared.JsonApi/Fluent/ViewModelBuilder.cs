using TheOmenDen.Shared.JsonApi.Interfaces.Includes;
using TheOmenDen.Shared.JsonApi.Interfaces.Links;
using TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;

namespace TheOmenDen.Shared.JsonApi.Fluent;

public sealed class ViewModelBuilder<TData> :
    ICanCreateAViewModel<TData>, ICanInclude<TData>
{
    private ViewModel<TData> _viewModelReference;

    private ViewModelBuilder()
    {
        _viewModelReference = ViewModel<TData>.Empty();
    }

    public static ICanCreateAViewModel<TData> CreateBuilder()
    {
        return new ViewModelBuilder<TData>();
    }
    #region Build From Data
    public ICanAddDetailsToAViewModel<TData> FromData(TData data)
    {
        _viewModelReference = new(data);

        return this;
    }

    public ICanAddDetailsToAViewModel<TData> FromData(String selfUrl, TData data)
    {
        _viewModelReference = new(selfUrl, data);

        return this;
    }

    public ViewModel<TData> Build()
    {
        return _viewModelReference;
    }

    #endregion

    public ICanAddLinksToAViewModel<TData> AddSelfLink()
    {
        return AddLink("self", $"{_viewModelReference.Type}/{_viewModelReference.Data.Id}");
    }

    public ICanAddDetailsToAViewModel<TData> AddLink(string name, string href)
    {
        if (string.IsNullOrEmpty(href))
        {
            throw new ArgumentNullException(paramName: nameof(href), message:@"Supplied link cannot be null");
        }

        if (_viewModelReference.GetLink(name) is not null)
        {
            throw new InvalidOperationException($"View Model already contains link with name '{name}'");
        }

        _viewModelReference.AddLink(name, href);

        return this;
    }

    public ICanInclude<TData> WithRelatedData()
    {
        return this;
    }

    public ICanAddDetailsToAViewModel<TData> Include<TIncluded>(TIncluded included)
    {
        return this;
    }

    public ICanAddLinksToAViewModel<TData> WithLinks()
    {
        _viewModelReference.InitializeLinkCollection();
        return this;
    }

    public ICanInclude<TData> AddRelationship<TIncluded>(String relationshipKey,TIncluded relationshipToInclude)
    {
        _viewModelReference.AddRelationship(relationshipKey, relationshipToInclude);    

        return this;
    }

    public ICanAddDetailsToAViewModel<TData> WithMeta(Meta meta)
    {
        _viewModelReference.AddMetaData(meta);

        return this;
    }

    public ICanInclude<TData> WithLink<TIncluded>(string relationshipKey, RelationLink link)
    {
        if (_viewModelReference.Relationships.TryGetValue(relationshipKey, out var relationship))
        {
            relationship.AddLink(link);

            return this;
        }

        throw new ArgumentOutOfRangeException($"Could not find Relationship with key {relationshipKey}");
    }

    public ICanInclude<TData> WithLink<TIncluded>(string relationshipKey, Link link)
    {
        if (_viewModelReference.Relationships.TryGetValue(relationshipKey, out var relationship))
        {
            relationship.AddLink(link);

            return this;
        }

        throw new ArgumentOutOfRangeException($"Could not find Relationship with key {relationshipKey}");
    }

    public ICanInclude<TData> WithLink<TIncluded>(string relationshipKey, string name, string href)
    {
        if (_viewModelReference.Relationships.TryGetValue(relationshipKey, out var relationship))
        {
            relationship.AddLink(name, href);

            return this;
        }

        throw new ArgumentOutOfRangeException($"Could not find Relationship with key {relationshipKey}");
    }

    public ICanInclude<TData> WithSelfLink<TIncluded>(string relationshipKey)
    {
        if(_viewModelReference.Relationships.TryGetValue(relationshipKey, out var relationship))
        {
            relationship.AddLink("self", $"{typeof(TIncluded).Name.ToLowerInvariant()}/{relationshipKey}");

            return this;
        }

        throw new ArgumentOutOfRangeException($"Could not find Relationship with key {relationshipKey}");
    }
}