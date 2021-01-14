using EmergentGameEngine.Abstraction.Entities;
using System.Collections.Generic;

namespace EmergentGameEngine.Entities.UnitTests.TestDoubles.Mocks
{
    public class AEntityMock : IEntity
    {
        public string Name { get; }
        public ulong Id { get; }
        public string Category => "A";
        public IEntityRegistry Registry { get; }

        public IEnumerable<string> Tags => throw new System.NotImplementedException();

        public AEntityMock(string name, ulong id, IEntityRegistry registry)
        {
            Name = name;
            Id = id;
            Registry = registry;
        }
    }
}
