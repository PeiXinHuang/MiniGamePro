using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public enum EntityType {
    Fruit = 1,
}

public class EntityManager : Manager<EntityManager>
{
    private Dictionary<EntityType, List<Entity>> entityDir;


    public EntityManager()
    {
        entityDir = new Dictionary<EntityType, List<Entity>>();
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
        if (!this.entityDir.ContainsKey(entityType))
        {
            this.entityDir.Add(entityType, new List<Entity>());
        }
        this.entityDir[entityType].Add(entity);
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

    public List<Entity> GetEntityWithComp<T>()
    {
        List<Entity> entities = new List<Entity>();
        foreach (var key in entityDir.Keys)
        {
            foreach (var item in entityDir[key])
            {
                entities.Add(item);
            }
        }
        return entities;
    }

}
