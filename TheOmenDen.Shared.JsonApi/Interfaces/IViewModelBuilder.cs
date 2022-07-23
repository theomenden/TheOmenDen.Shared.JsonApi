namespace TheOmenDen.Shared.JsonApi.Interfaces;

public interface IViewModelBuilder
{
    ViewModel<TData> Initialize<TData>(TData data);

    void Finalize<TData>();
}

