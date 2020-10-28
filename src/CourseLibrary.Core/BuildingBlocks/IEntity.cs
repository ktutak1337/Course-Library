namespace CourseLibrary.Core.BuildingBlocks
{
    public interface IEntity<out TEntityId> 
        where TEntityId: TypedIdValueBase
    {
         TEntityId Id { get; }
    }
}
