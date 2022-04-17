// Author: liuweichicun
// Email: liuweichicun@outlook.com
// CreateTime: 2022/04/17 14:30

namespace ECS
{
    /// <summary>
    /// 获取 World 中指定类型的 System
    /// </summary>
    public interface ISystemItr
    {
        /// <summary>
        /// 获取 World 中指定类型的 System
        /// </summary>
        /// <typeparam name="T">指定的 System 类型，该类型继承自 <see cref="System"/></typeparam>
        /// <returns>World 中指定类型的 System</returns>
        T GetSystem<T>() where T : System;
    }
}