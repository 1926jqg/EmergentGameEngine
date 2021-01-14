namespace EmergentGameEngine.Abstraction.Entities
{
    public interface IEntityFactory
    {
        string Category { get; }
        IEntity GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters);
    }

    public interface IEntityFactory<T> : IEntityFactory
        where T : class, IEntity
    {
        new T GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters);
    }
}
