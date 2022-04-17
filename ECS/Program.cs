namespace ECS
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // 创建世界
            World world = new World();

            // 往世界里加入 entity 和 system
            Entity entity = new Entity();
            entity.EntityId = 0;
            Transform transform = new Transform();
            entity.AddComponent(transform);
            CharacterData characterData = new CharacterData();
            characterData.id = 1;
            characterData.name = "张三";
            characterData.avatar = "zhangsan";
            characterData.desc = "遵纪守法好公民";
            entity.AddComponent(characterData);

            CharacterMoveSystem characterMoveSystem = new CharacterMoveSystem();
            CharacterDataSystem characterDataSystem = new CharacterDataSystem();
            world.AddEntity(entity);
            world.AddSystem(characterMoveSystem);
            world.AddSystem(characterDataSystem);

            // 让世界动起来，开始模拟世界
            world.StartLoop();

            // 执行一些非自动的逻辑
            Console.WriteLine(characterData.name + "," + characterData.avatar + "," + characterData.desc);
            var cds = world.GetSystem<CharacterDataSystem>();
            cds.Rename(1, "李四");
            cds.ChangeAvatar(1, "lisi");
            Console.WriteLine(characterData.name + "," + characterData.avatar + "," + characterData.desc);

            while (true)
            {
                if (world.IsStop)
                    break;
            }
        }
    }
}