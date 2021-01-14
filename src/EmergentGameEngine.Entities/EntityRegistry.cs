using EmergentGameEngine.Abstraction.Entities;
using System;
using System.Collections.Generic;

namespace EmergentGameEngine.Entities
{
    public class EntityRegistry : IEntityRegistry
    {
        private readonly IDictionary<string, IEntityFactory> _entityFactoriesByCategory = new Dictionary<string, IEntityFactory>();
        private readonly IDictionary<Type, IEntityFactory> _entityFactoriesByType = new Dictionary<Type, IEntityFactory>();
        private readonly IDictionary<ulong, IEntity> _entities = new Dictionary<ulong, IEntity>();
        private ulong _nextId;

        protected ulong GetNextId()
        {
            return _nextId++;
        }

        protected bool TryGetFactory<T>(out IEntityFactory<T> entityFactory) where T : class, IEntity
        {
            if (!_entityFactoriesByType.TryGetValue(typeof(T), out IEntityFactory genericFactory))
            {
                entityFactory = null;
                return false;
            }
            entityFactory = genericFactory as IEntityFactory<T>;
            return genericFactory is IEntityFactory<T>;
        }

        protected bool TryGetFactory(string category, out IEntityFactory entity)
        {
            return _entityFactoriesByCategory.TryGetValue(category, out entity);
        }

        protected bool TryGetCategoryForType(Type type, out string category)
        {
            category = null;
            if (!_entityFactoriesByType.TryGetValue(type, out IEntityFactory factory))
                return false;
            category = factory.Category;
            return true;
        }

        protected void AddEntity(IEntity entity)
        {
            _entities.Add(entity.Id, entity);
        }

        public bool TryAddFactory(IEntityFactory entityFactory)
        {
            if (TryGetFactory(entityFactory.Category, out _))
                return false;

            _entityFactoriesByCategory.Add(entityFactory.Category, entityFactory);
            return true;
        }

        public bool TryAddFactory<T>(IEntityFactory<T> entityFactory) where T : class, IEntity
        {
            if (TryGetFactory(entityFactory.Category, out _) ||
                TryGetFactory<T>(out _))
            {
                return false;
            }
            _entityFactoriesByCategory.Add(entityFactory.Category, entityFactory);
            _entityFactoriesByType.Add(typeof(T), entityFactory);

            return true;
        }

        public bool TryCreateEntity(string category, out IEntity entity, params (string, object)[] parameters)
        {

            if (!_entityFactoriesByCategory.TryGetValue(category, out IEntityFactory entityFactory))
            {
                entity = null;
                return false;
            }
            entity = entityFactory.GetEntity(GetNextId(), this, parameters);
            AddEntity(entity);
            return true;
        }

        public bool TryCreateEntity<T>(out T entity, params (string, object)[] paramaters) where T : class, IEntity
        {

            if (!TryGetFactory(out IEntityFactory<T> entityFactory))
            {
                entity = null;
                return false;
            }
            entity = entityFactory.GetEntity(GetNextId(), this, paramaters);
            AddEntity(entity);
            return true;
        }

        public bool TryGetEntity(ulong id, out IEntity entity)
        {
            return _entities.TryGetValue(id, out entity);
        }

        public bool TryGetEntity<T>(ulong id, out T entity) where T : class, IEntity
        {
            entity = default;
            if (!TryGetEntity(id, out IEntity genericEntity) ||
                !TryGetCategoryForType(typeof(T), out string category) ||
                genericEntity.Category != category)
            {
                return false;
            }
            entity = genericEntity as T;
            return true;
        }
    }
}
