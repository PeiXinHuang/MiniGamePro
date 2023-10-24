using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public static int _instanceId = 0;  
    public int entityId { get; }
    public List<BaseComponent> components = null;
    public Entity()
    {
        _instanceId++;
        this.entityId = _instanceId;
    }

    public void AddComponent<T>() where T : BaseComponent, new()
    {
        if(components == null)
        {
            components = new List<BaseComponent>();
        }
        T t = new T();
        t.Init(this);
        component.Add(t);
        return t;
    }

    public bool HasComponent<T>() where T :BaseComponent
    {
        if(components == null)
        {
            return false;
        }
        foreach(BaseComponent component in components)
        {
            if(component.GetType() == typeof(T))
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveComponent(BaseComponent comp)
    {
        if(components != null)
        {
            components.Remove(comp)
            comp.Dispose();
        }
    }

    public T GetComponent<T>() where T : BaseComponent
    {
        if(components == null)
        {
            return null;
        }
        foreach(BaseComponent component in components)
        {
            if(component.GetType() == typeof(T))
            {
                return (T)component;
            }
        }           
        return null;
    }

    public T GetComponents<T>() where T : BaseComponent
    {
        List<T> ret = new List<T>();
        if(components == null)
        {
            return ret;
        }
        foreach(BaseComponent component in components)
        {
            if(component.GetType() == typeof(T))
            {
                ret.Add((T)component);
            }
        }
        return null;
    }

    public virtual void Dispose()
    {
       if(components != null)   
       {
            foreach(BaseComponent comp in comp)
            {
                comp.Dispose();
            }
            components = null;
       }
    }
}
