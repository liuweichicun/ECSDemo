// Author: liuweichicun
// Email: liuweichicun@outlook.com
// CreateTime: 2022/04/17 12:15

namespace ECS
{
    /// <summary>
    /// 获取 World 中指定类型的 Components
    /// </summary>
    public interface IComponentItr
    {
        /// <summary>
        /// 获取 World 中指定类型的 Components
        /// </summary>
        /// <typeparam name="T">指定的 Component 类型，该类型继承自 <see cref="Component"/></typeparam>
        /// <returns>World 中指定类型的 Components </returns>
        List<T> GetComponents<T>() where T : Component;
    }
}