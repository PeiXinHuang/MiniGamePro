using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEventComponent : BaseComponent
{
    private Entity other;
    public ColliderEventComponent()
    {

    }
    public override void Init(Entity entity)
    {
        base.Init(entity);
        if(!entity.HasComponent<ColliderComponent>())
        {
            Debug.LogError("You cannnot add entity ColliderEventComponent without colliderComponent");
        }
    }
}
