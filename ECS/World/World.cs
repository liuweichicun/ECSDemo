// Author: liuweichicun
// Email: liuweichicun@outlook.com
// CreateTime: 2022/04/17 11:32
namespace ECS
{
     /// <summary>
     /// 由 Entities 和  System 共同构成的”世界“
     /// </summary>
     public class World : IComponentItr, ISystemItr
     {
          /// <summary>
          /// 所有的 Entities
          /// </summary>
          private readonly List<Entity> _entities = new List<Entity>();

          /// <summary>
          /// 所有的 Systems
          /// </summary>
          private readonly List<System> _systems = new List<System>();

          /// <summary>
          /// 是否暂停
          /// </summary>
          private bool _isPause = false;

          /// <summary>
          /// 暂停开始时间戳
          /// </summary>
          private long _pauseStartTimestamp = 0L;

          /// <summary>
          /// 暂停结束时间戳
          /// </summary>
          private long _pauseEndTimestamp = 0L;

          /// <summary>
          /// 世界是否停止模拟
          /// </summary>
          private bool _isStop;

          /// <summary>
          /// 世界是否停止模拟
          /// </summary>
          public bool IsStop => _isStop;

          /// <summary>
          /// 向世界中添加 Entity
          /// </summary>
          /// <param name="entity">要添加的 Entity</param>
          public void AddEntity(Entity entity)
          {
               _entities.Add(entity);
          }

          /// <summary>
          /// 从世界中移除 Entity
          /// </summary>
          /// <param name="entity">要移除的 Entity</param>
          public void RemoveEntity(Entity entity)
          {
               _entities.Remove(entity);
          }

          /// <summary>
          /// 向世界中添加 System
          /// </summary>
          /// <param name="system">要添加的 System</param>
          public void AddSystem(System system)
          {
               system._componentItr = this;
               _systems.Add(system);
          }

          /// <summary>
          /// 从世界中移除 System
          /// </summary>
          /// <param name="system">要移除的 System</param>
          public void RemoveSystem(System system)
          {
               _systems.Remove(system);
          }

          /// <summary>
          /// 开始自动模拟
          /// </summary>
          public async void StartLoop()
          {
               long startTimestamp = DateTime.UtcNow.Ticks;
               long currentTimestamp = startTimestamp;
               while (true)
               {
                    if (_isPause) continue;
                    if (_isStop) break;
                    foreach (var system in _systems)
                    {
                         system.Update(
                              (currentTimestamp - startTimestamp - (_pauseEndTimestamp - _pauseStartTimestamp)) /
                              10000L);
                    }

                    await Task.Delay(13);
                    currentTimestamp = DateTime.UtcNow.Ticks;
               }
          }

          /// <summary>
          /// 暂停模拟
          /// </summary>
          public void Pause()
          {
               _isPause = true;
               _pauseStartTimestamp = DateTime.UtcNow.Ticks;
          }

          /// <summary>
          /// 继续模拟
          /// </summary>
          public void Resume()
          {
               if (_isPause)
                    _pauseEndTimestamp = DateTime.UtcNow.Ticks;
               _isPause = false;
          }

          /// <summary>
          /// 停止模拟
          /// </summary>
          public void Stop()
          {
               _isStop = true;
          }

          public List<T> GetComponents<T>() where T : Component
          {
               var baseComponents = new List<T>();
               foreach (var entity in _entities)
               {
                    foreach (var component in entity.GetComponents())
                    {
                         if (component is T c)
                              baseComponents.Add(c);
                    }
               }

               return baseComponents;
          }

          public T GetSystem<T>() where T : System
          {
               foreach (var system in _systems)
               {
                    if (system is T s)
                         return s;
               }

               return default;
          }
     }
}