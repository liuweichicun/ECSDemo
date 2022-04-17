// Author: liuweichicun
// Email: liuweichicun@outlook.com
// CreateTime: 2022/04/17 12:40
namespace ECS
{
    /// <summary>
    /// 示例 Component
    /// </summary>
    public class Transform : Component
    {
        public Vector3 postion;
        public Quaternion rotaion;
        public Vector3 scale;

        public override string ToString()
        {
            return "transform: pos { x: " + postion.x + " y: " + postion.y + " z: " + postion.z + " }";
        }
    }
}