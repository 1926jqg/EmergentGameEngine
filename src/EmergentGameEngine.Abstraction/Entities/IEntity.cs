using System.Collections.Generic;

namespace EmergentGameEngine.Abstraction.Entities
{
    public interface IEntity
    {
        string Name { get; }
        ulong Id { get; }
        IEnumerable<string> Tags { get; }
        string Category { get; }        
        IEntityRegistry Registry { get; }
    }
}
