using EmergentGameEngine.Abstraction.Entities;
using EmergentGameEngine.Entities.UnitTests.TestDoubles.Mocks;
using System;
using System.Linq;

namespace EmergentGameEngine.Entities.UnitTests.TestDoubles.Fakes
{
    public class AEntityFactoryFake : IEntityFactory<AEntityMock>
    {
        public string Category => "A";

        public AEntityMock GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters)
        {
            var name = parameters.Where(p => p.Item1 == "A")
                .Select(p => p.Item2 as string)
                .FirstOrDefault();
            if (name == null)
                throw new ArgumentException("Parameter \"name\" was missing");
            return new AEntityMock(name, id, registry);
        }

        IEntity IEntityFactory.GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters)
        {
            return GetEntity(id, registry, parameters);
        }
    }
}
