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
            Debug.LogWarning("û����Ҫ�����EntityType���ͣ�" + entityType.ToString());
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
        //    UDebug.LogWarning("û���ҵ�Entity, Id��" + entityId.ToString());
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
