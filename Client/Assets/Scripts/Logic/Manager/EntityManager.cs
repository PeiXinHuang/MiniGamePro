using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public enum EntityType {
    Fruit = 1,
}

public class EntityManager : Manager<EntityManager>
{
    private Dictionary<EntityType, List<Entity>> entityTypeDir;
    private Dictionary<int, Entity> entityIdDir;

    public EntityManager()
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
            Debug.LogWarning("没有需要构造的EntityType类型：" + entityType.ToString());
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
        //    UDebug.LogWarning("没有找到Entity, Id：" + entityId.ToString());
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
