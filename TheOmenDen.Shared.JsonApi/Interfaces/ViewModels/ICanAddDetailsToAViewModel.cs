using TheOmenDen.Shared.JsonApi.Interfaces.Includes;
using TheOmenDen.Shared.JsonApi.Interfaces.Links;

namespace TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;

    public interface ICanAddDetailsToAViewModel<TData>
        : ICanAddLinksToAViewModel<TData>, ICanInclude<TData>
    {
        ICanAddDetailsToAViewModel<TData> WithLinks();

        ICanInclude<TData> WithRelatedData<TIncluded>(String relationshipKey,TIncluded relationshipToInclude);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ViewModel<TData> Build();
}
