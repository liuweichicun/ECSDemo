// Author: liuweichicun
// Email: liuweichicun@outlook.com
// CreateTime: 2022/04/17 12:18

namespace ECS
{
    /// <summary>
    /// 示例 System
    /// </summary>
    public class CharacterMoveSystem : System
    {
        public override void Update(long timestamp)
        {
            foreach (var component in _componentItr.GetComponents<Transform>())
            {
                // 这里可以写一些键盘监听，对 Transform 的值进行修改
                // Console.WriteLine("transform: " + component.ToString());
            }
        }
    }
}