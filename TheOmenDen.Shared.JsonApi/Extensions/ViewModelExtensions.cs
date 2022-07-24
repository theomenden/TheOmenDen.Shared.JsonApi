namespace TheOmenDen.Shared.JsonApi.Extensions;

public static class ViewModelExtensions
{
    public static IViewModel GetViewModel<T>(this T data, Uri requestPath)
    where T : class
    {
        return new ViewModel<T>(requestPath.ToString(), data);
    }

    public static IViewModel GetViewModel<T>(this T data, EntityId<T> entityId)
    {
        return new ViewModel<T>($"/{entityId.Id}",data);
    }
}

