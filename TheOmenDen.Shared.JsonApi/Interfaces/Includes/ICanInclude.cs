using TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;

namespace TheOmenDen.Shared.JsonApi.Interfaces.Includes;
public interface ICanInclude<TData>
{
    ICanAddDetailsToAViewModel<TData> Include<TIncluded>(TIncluded included);
}

