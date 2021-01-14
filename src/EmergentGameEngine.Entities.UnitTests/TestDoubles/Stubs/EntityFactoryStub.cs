using EmergentGameEngine.Abstraction.Entities;

namespace EmergentGameEngine.Entities.UnitTests.TestDoubles.Stubs
{
    public class EntityFactoryStub : IEntityFactory
    {
        public string Category { get; }

        public EntityFactoryStub(string category)
        {
            Category = category;
        }

        public IEntity GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
