using EmergentGameEngine.Abstraction.Entities;
using System.Collections.Generic;

namespace EmergentGameEngine.CharacterModel
{
    public interface ICharacter : IEntity
    {
    }
    public class Character : ICharacter
    {
        public string Name { get; }
        public ulong Id { get; }
        public IEntityRegistry Registry { get; }

        public string Category => CharacterModelContants.CHARACTER_CATEGORY;

        protected IList<string> _tags = new List<string>();
        public IEnumerable<string> Tags => _tags;


        internal Character(ulong id, IEntityRegistry registry)
        {
            Id = id;
            Registry = registry;
        }

    }
}
