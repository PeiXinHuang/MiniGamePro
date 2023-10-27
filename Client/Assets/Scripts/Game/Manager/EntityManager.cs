using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class EntityManager : SingletonMonoBehaviour<EntityManager>
{
    private PlayerEntity player = null;
    private List<Entity> entities = null;
    private Dictionary<System.Type, List<Entity>> entityDir = null;

    public override void Init()
    {
        entities = new List<Entity>();
        entityDir =  Dictionary<System.Type, List<Entity>>();
        
    }

    public int GetEntityCountWithType<T>() where T : Entity
    {
        if(!entityDir.ContainsKey(typeof(T)))
        {
            return 0;
        }
        return entityDir[typeof(T)].Count;
    }

    public PlayerEntity GetPlayEntity()
    {
        return player;
    }

    
    public List<Entity> GetEntityWithType<T>() where T : Entity
    {
        if(!entityDir.ContainsKey(typeof(T)))
        {
            return new List<Entity>();
        }
        return entityDir[typeof(T)];
    }

    public List<Entity> GetEntityWithTypeComp<T, C>() where T : Entity where C :BaseComponent
    {
        List<Entity> ret = new List<Entity>();
        if(!entityDir.ContainsKey(typeof(T)))
        {
            return ret;
        }
        foreach(var entity in entityDir[(typeof(T)])
        {
            if(entity.HasComponent<C>())
            {
                ret.Add(entity);
            }
        }
        return ret;
    }

    
    public void AddEntity<T>(Entity entity) where T : Entity
    {
         if(!entityDir.ContainsKey(typeof(T)))
        {
            entityDir[typeof(T)] = new List<Entity>();
        }
        entityDir[typeof(T)].Add(entity);
        entities.Add(entity);
    }

    public void RemoveEntity(int entityId)
    {
        if(entities != null){
            entities.Remove(entity);
        }
        if(entityDir != null && entityDir.ContainsKey(entity.GetType()))
        {
            entityDir[typeof(T)].Remove(entity);
        }
        entity.Dispose();
    }


    public override void Dispose()
    {
        foreach(var entity in entities)
        {
            entity.Dispose();
        }
        entities = null;
        entityDir = null;
    }

    public void OnDestroy()
    {
        Dispose();
    }

    public PlayEntity CreatePlayer()
    {
        if(player == null)
        {
            PlayerEntity playerEntity = new PlayerEntity();
            var dataComp = playerEntity.AddComponent<DataComponent>();
            playerEntity.AddComponent<PlayControlComponent>();
            playerEntity.AddComponent<TransformComponent>();
            RenderComponent render = playerEntity.AddComponent<RenderComponent>();
            render.InitGameObject("Prefabs/Player");

            ColliderComponent ColliderComp = playerEntity.AddComponent<ColliderComponent>();
            ColliderComp.SetColliderBox(new Vector2(0.3f,0.3f));
            ColliderComp.SetColliderCenter(Vector2.zero));
            ColliderComp.SetRigidBody();
            AddEntity<PlayerEntity>(playerEntity);

            player = playerEntity;
        }
        else
        {
            Debug.LogError("已经存在玩家，不重复创建");
        }
        return player;
    }

    public PlayEntity CreateMonster(Vector3 pos, Color color, Transform parent = null)
    {
      
        MonsterEntity monsterEntity = new MonsterEntity();
        var monsterEntity = monsterEntity.AddComponent<DataComponent>();
        TransformComponent tran = monsterEntity.AddComponent<TransformComponent>();
        tran.pos = pos;
        RenderComponent render = monsterEntity.AddComponent<RenderComponent>();
        render.InitGameObject("Prefabs/Monster", parent);
        render.gameObject.GetComponent<SpriteRenderer>().color = color;
        ColliderComponent ColliderComp = monsterEntity.AddComponent<ColliderComponent>();
        ColliderComp.SetColliderBox(new Vector2(0.3f,0.3f));
        ColliderComp.SetColliderCenter(Vector2.zero));
        ColliderComp.SetRigidBody();
        AddEntity<MonsterEntity>(monsterEntity);
        return monsterEntity;
    }

    public PlayEntity CreateGood(Vector3 pos, Transform parent = null)
    {
      
        GoodEntity goodEntity = new GoodEntity();
        var dataComp = goodEntity.AddComponent<DataComponent>();
        TransformComponent tran = goodEntity.AddComponent<TransformComponent>();
        tran.pos = pos;
        RenderComponent render = goodEntity.AddComponent<RenderComponent>();
        render.InitGameObject("Prefabs/Good", parent);
        ColliderComponent ColliderComp = goodEntity.AddComponent<ColliderComponent>();
        ColliderComp.SetColliderBox(new Vector2(0.5f,0.5f));
        ColliderComp.SetColliderCenter(Vector2.zero));
        ColliderComp.SetRigidBody();
        AddEntity<GoodEntity>(goodEntity);
        return goodEntity;
    }

    public PlayEntity CreateSkill(Entity entity, SkillType SkillType, Vector3 pos, Transform parent = null)
    {
      
        SkillEntity skillEntity;
        TransformComponent tran;
        switch(SkillType)
        {
            case SkillType.Explose:
                skillEntity = new ExploseSkillEntity(entity);
                tran = skillEntity.AddComponent<TransformComponent>();
                tran.pos = pos;
                var render = skillEntity.AddComponent<RenderComponent>();
                render.InitGameObject("Prefabs/Explose", parent);
                break;
            default:
                skillEntity = new ExploseSkillEntity(entity);
                tran = skillEntity.AddComponent<TransformComponent>();
                tran.pos = pos;
                break;
        }

        AddEntity<SkillEntity>(skillEntity);
        return skillEntity;
    }
}
