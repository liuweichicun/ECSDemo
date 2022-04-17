// Author: liuweichicun
// Email: liuweichicun@outlook.com
// CreateTime: 2022/04/17 14:18
namespace ECS{
    /// <summary>
    /// 示例 System
    /// </summary>
    public class CharacterDataSystem : System
    {
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="id">characterData 的 id</param>
        /// <param name="name">想要替换的新名字</param>
        public void Rename(int id, string name)
        {
            foreach (var component in _componentItr.GetComponents<CharacterData>())
            {
                if (component.id == id)
                {
                    component.name = name;
                }
            }
        }

        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="id">charcterData 的 id</param>
        /// <param name="avatar">想要替换的新图片名</param>
        public void ChangeAvatar(int id, string avatar)
        {
            foreach (var component in _componentItr.GetComponents<CharacterData>())
            {
                if (component.id == id)
                {
                    component.avatar = avatar;
                }
            }
        }

    }
}