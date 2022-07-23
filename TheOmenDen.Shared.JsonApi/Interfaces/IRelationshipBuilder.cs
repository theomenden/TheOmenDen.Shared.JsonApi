namespace TheOmenDen.Shared.JsonApi.Interfaces;

public interface IRelationshipBuilder
{
    IViewModelBuilder AddRelationshipToModel<TData>(TData data);
}
