using TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;

namespace TheOmenDen.Shared.JsonApi.Interfaces.Links;

public interface ICanAddLinksToAViewModel<TData>
{
    ICanAddDetailsToAViewModel<TData> AddSelfLink();

    ICanAddDetailsToAViewModel<TData> AddLink(String name, String href);
}
