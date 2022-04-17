// Author: liuweichicun
// Email: liuweichicun@outlook.com
// CreateTime: 2022/04/17 11:30
namespace ECS
{
    /// <summary>
    /// Entity 仅包含 Entity ID 和一些 component
    /// </summary>
    public class Entity : IEquatable<Entity>
    {
        public int EntityId;
        private readonly List<Component> _components = new List<Component>();

        public List<Component> GetComponents()
        {
            return _components;
        }

        public void AddComponent(Component component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(Component component)
        {
            _components.Remove(component);
        }

        public bool Equals(Entity? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EntityId == other.EntityId;
        }
    }
}