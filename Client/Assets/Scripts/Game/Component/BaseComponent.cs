using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent
{
    public Entity entity;
    public BaseComponent()
    {

    }
    public virtual void Init(Entity entity)
    {
        this.entity = entity;
    }
    public virtual void Dispose()
    {

    }
}
