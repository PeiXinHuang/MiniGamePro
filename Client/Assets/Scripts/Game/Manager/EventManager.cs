using System;
using System.Collections.Generic;
using UnityEngine;
public class EventManager : SingletonMonoBehaviour<EventManager>
{
    private Dictionary<string, Delegate> eventDir;
    public override void Init()
    {
        base.Init();
        eventDir = new Dictionary<string, Delegate>();
    }
    public void AddListener(string eventName, Action eventHandler)
    {
        if(!eventDir.ContainKey(eventName))
        {
            eventDir[eventName] = eventHandler;
        }
        else
        {
            eventDir[eventName] = (Action)eventDir[eventName] + eventHandler;
        }
    }

    public void AddListener<T>(string eventName, Action<T> eventHandler)
    {
        if(!eventDir.ContainKey(eventName))
        {
            eventDir[eventName] = eventHandler;
        }
        else
        {
            eventDir[eventName] = (Action<T>)eventDir[eventName] + eventHandler;
        }
    }

    public void AddListener<T1, T2>(string eventName, Action<T1, T2> eventHandler)
    {
        if(!eventDir.ContainKey(eventName))
        {
            eventDir[eventName] = eventHandler;
        }
        else
        {
            eventDir[eventName] = (Action<T1, T2>)eventDir[eventName] + eventHandler;
        }
    }

    public void RemoveListener(string eventName, Action eventHandler)
    {
        if(eventDir.ContainKey(eventName))
        {
            eventDir[eventName] = (Action)eventDir[eventName] - eventHandler;
        }
    }

    public void RemoveListener<T>(string eventName, Action<T> eventHandler)
    {
        if(eventDir.ContainKey(eventName))
        {
            eventDir[eventName] = (Action<T>)eventDir[eventName] - eventHandler;
        }
    }

    public void RemoveListener<T1, T2>(string eventName, Action<T1, T2> eventHandler)
    {
        if(eventDir.ContainKey(eventName))
        {
            eventDir[eventName] = (Action<T1, T2>)eventDir[eventName] - eventHandler;
        }
    }

    public void TriggerEvent(string eventName)
    {
        Delegate d;
        if(!eventDir.TryGetValue(eventName, out d))
        {
            return;
        }

        Delegate[] callbacks = d.GetInvocationList();

        for(int i = 0; i < callbacks.Length; i++)
        {
            Action callback = callback[i] as Action;
            if(callback == null)
            {
                throw new Exception("Get Action Fail " + eventName);
            }
            try 
            {
                callback();
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
    }

    
    public void TriggerEvent<T>(string eventName, T arg1)
    {
        Delegate d;
        if(!eventDir.TryGetValue(eventName, out d))
        {
            return;
        }

        Delegate[] callbacks = d.GetInvocationList();

        for(int i = 0; i < callbacks.Length; i++)
        {
            Action<T> callback = callback[i] as Action<T>;
            if(callback == null)
            {
                throw new Exception("Get Action Fail " + eventName);
            }
            try 
            {
                callback(arg1);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
    }

    public void TriggerEvent<T1, T2>(string eventName, T1 arg1, T2 arg2)
    {
        Delegate d;
        if(!eventDir.TryGetValue(eventName, out d))
        {
            return;
        }

        Delegate[] callbacks = d.GetInvocationList();

        for(int i = 0; i < callbacks.Length; i++)
        {
            Action<T1, T2> callback = callback[i] as Action<T1, T2>;
            if(callback == null)
            {
                throw new Exception("Get Action Fail " + eventName);
            }
            try 
            {
                callback(arg1, arg2);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
    }
}