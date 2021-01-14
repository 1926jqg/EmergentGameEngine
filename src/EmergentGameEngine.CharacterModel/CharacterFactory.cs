using EmergentGameEngine.Abstraction.Entities;

namespace EmergentGameEngine.CharacterModel
{
    public class CharacterFactory : IEntityFactory<ICharacter>
    {
        public string Category => CharacterModelContants.CHARACTER_CATEGORY;

        public ICharacter GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters)
        {
            return new Character(id, registry);
        }

        IEntity IEntityFactory.GetEntity(ulong id, IEntityRegistry registry, params (string, object)[] parameters)
        {
            return GetEntity(id, registry, parameters);
        }
    }
}
