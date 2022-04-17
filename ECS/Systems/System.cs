// Author: liuweichicun
// Email: liuweichicun@outlook.com
// CreateTime: 2022/04/17 11:19
namespace ECS
{
    /// <summary>
    /// 所有 System 的共有父类，所有的 System 都要继承此类
    /// </summary>
    public abstract class System : IEquatable<System>
    {
        public IComponentItr _componentItr;


        /// <summary>
        /// 保留的自动刷新方法
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        public virtual void Update(long timestamp)
        {
        }

        public bool Equals(System? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GetType() == other.GetType();
        }
    }
}