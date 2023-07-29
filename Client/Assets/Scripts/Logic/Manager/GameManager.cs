using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public List<BaseSystem> systems = null;
    public override void Initialize()
    {
        systems = new List<BaseSystem>();
    }
    void Update()
    {
        foreach (var system in systems)
        {
            system.Update();
        }
    }
    public void StartGame(int levelId)
    {
        for (int i = 0; i < 10; i++)
        {
            EntityManager.Instance.CreateEntity(EntityType.Fruit);
        }
        systems.Add(new TransformUpdateSystem());
        systems.Add(new RenderSystem());
    }
}
