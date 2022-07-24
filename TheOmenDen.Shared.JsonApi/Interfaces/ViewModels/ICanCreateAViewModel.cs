namespace TheOmenDen.Shared.JsonApi.Interfaces.ViewModels;
public interface ICanCreateAViewModel<TData> : ICanAddDetailsToAViewModel<TData>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    ICanCreateAViewModel<TData> FromData(TData data);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="selfUrl"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    ICanCreateAViewModel<TData> FromData(String selfUrl, TData data);

}

