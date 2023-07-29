using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public static int _instanceId = 0;  
    public int entityId { get; }
    public Dictionary<System.Type, object> components = null;
    public Entity()
    {
        _instanceId++;
        this.entityId = _instanceId;
        components = new Dictionary<System.Type, object>();
    }

    public void AddComponent<T>(T component)
    {
        System.Type componentType = typeof(T);
        if (components.ContainsKey(componentType))
        {
            UDebug.LogWarning("��Ҫ�ظ����Component");
        }
        else
        {
            components.Add(typeof(T), component);
        }
    }

    public void RemoveComponent<T>()
    {
        System.Type componentType = typeof(T);
        if (components.ContainsKey(componentType))
        {
            components.Remove(componentType);
        }
        else
        {
            UDebug.LogWarning("��ͼ�Ƴ������ڵ�Component");
        }
    }

    public T GetComponent<T>()
    {
        System.Type componentType = typeof(T);
        if (components.ContainsKey(componentType))
        {
            return (T)components[componentType];
        }
        else
        {
            UDebug.LogWarning("��ͼ��ȡ�����ڵ�Component");
            return default(T);
        }
    }

    public void SetComponent<T>(T component)
    {
        System.Type componentType = typeof(T);
        if (components.ContainsKey(componentType))
        {
            components.Remove(componentType);
        }
        components.Add(componentType, component);
    }
}
