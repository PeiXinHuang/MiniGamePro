using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class EntityManager : SingletonMonoBehaviour<EntityManager>
{
    private Dictionary<EntityType, List<Entity>> entityTypeDir;
    private Dictionary<int, Entity> entityIdDir;

    public override void Init()
    {
        entityTypeDir = new Dictionary<EntityType, List<Entity>>();
        entityIdDir = new Dictionary<int, Entity>();
    }

    public Entity CreateEntity(EntityType entityType)
    {
        Entity entity = null;
        if (entityType == EntityType.Fruit)
        {
            entity = new FruitEntity();
        }
        else
        {
            Debug.LogWarning("û����Ҫ�����EntityType���ͣ�" + entityType.ToString());
        }
        if (!this.entityTypeDir.ContainsKey(entityType))
        {
            this.entityTypeDir.Add(entityType, new List<Entity>());
        }
        this.entityTypeDir[entityType].Add(entity);
        this.entityIdDir.Add(entity.entityId, entity);
        return entity;
    }

    public void RemoveEntity(int entityId)
    {
        //if (entityComponents.ContainsKey(entityId))
        //{
        //    entityComponents.Remove(entityId);
        //}
        //else
        //{
        //    UDebug.LogWarning("û���ҵ�Entity, Id��" + entityId.ToString());
        //}
    }

    public Entity GetEntityById(int entityId)
    {
        return this.entityIdDir[entityId];
    }

    public List<Entity> GetEntityWithComp<T>()
    {
        List<Entity> entities = new List<Entity>();
        foreach (var key in entityTypeDir.Keys)
        {
            foreach (var item in entityTypeDir[key])
            {
                entities.Add(item);
            }
        }
        return entities;
    }

}
