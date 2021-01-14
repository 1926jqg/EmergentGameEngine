using EmergentGameEngine.Abstraction.Entities;
using EmergentGameEngine.Entities.UnitTests.TestDoubles.Mocks;
using System;
using System.Linq;

namespace EmergentGameEngine.Entities.UnitTests.TestDoubles.Fakes
{
    public class BEntityFactoryFake : IEntityFactory<BEntityMock>
    {
        public string Category => "B";

        public BEntityMock GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters)
        {
            var name = parameters.Where(p => p.Item1 == "B")
                .Select(p => p.Item2 as string)
                .FirstOrDefault();
            if (name == null)
                throw new ArgumentException("Parameter \"name\" was missing");
            return new BEntityMock(name, id, registry);
        }

        IEntity IEntityFactory.GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters)
        {
            return GetEntity(id, registry, parameters);
        }
    }
}
