namespace EmergentGameEngine.Abstraction.Entities
{
    public interface IEntityRegistry
    {
        bool TryAddFactory(IEntityFactory entityFactory);
        bool TryAddFactory<T>(IEntityFactory<T> entityFactory) where T : class, IEntity;
        bool TryCreateEntity(string category, out IEntity entity, params (string, object)[] paramaters);
        bool TryCreateEntity<T>(out T entity, params (string, object)[] paramaters) where T : class, IEntity;
        bool TryGetEntity(ulong id, out IEntity entity);
        bool TryGetEntity<T>(ulong id, out T entity) where T : class, IEntity;
    }
}
