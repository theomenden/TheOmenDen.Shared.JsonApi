namespace TheOmenDen.Shared.JsonApi.Interfaces.Links;

public interface ILinkCollectionBuilder
{
    IEnumerable<Link> InitializeLinkCollection();

    ILinkCollectionBuilder AddSelfLink();
}