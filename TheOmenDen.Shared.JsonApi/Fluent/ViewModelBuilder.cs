using TheOmenDen.Shared.JsonApi.Interfaces.Includes;
using TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;

namespace TheOmenDen.Shared.JsonApi.Fluent;

public sealed class ViewModelBuilder<TData> :
    ICanCreateAViewModel<TData>
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
    public ICanCreateAViewModel<TData> FromData(TData data)
    {
        _viewModelReference = new(data);

        return this;
    }

    public ICanCreateAViewModel<TData> FromData(String selfUrl, TData data)
    {
        _viewModelReference = new(selfUrl, data);

        return this;
    }

    public ViewModel<TData> Build()
    {
        return _viewModelReference;
    }

    #endregion

    public ICanAddDetailsToAViewModel<TData> AddSelfLink()
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

    public ICanAddDetailsToAViewModel<TData> Include<TIncluded>(TIncluded included)
    {
        
        return this;
    }

    public ICanAddDetailsToAViewModel<TData> WithLinks()
    {
        _viewModelReference.InitializeLinkCollection();
        return this;
    }

    public ICanInclude<TData> WithRelatedData<TIncluded>(String relationshipKey,TIncluded relationshipToInclude)
    {
        var relationship = _viewModelReference.AddRelationship(relationshipKey, relationshipToInclude);
        
        

        return this;
    }
}