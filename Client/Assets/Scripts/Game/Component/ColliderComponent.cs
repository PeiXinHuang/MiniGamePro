using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderComponent : BaseComponent
{
    private BoxCollider collider;
    private Rigidbody2D Rigidbody2D;
    public ColliderComponent()
    {

    }
    public override void Init(Entity entity)
    {
        base.Init(entity);
        if(entity.HasComponent<RenderComponent>())
        {
            var render = entity.GetComponent<RenderComponent>();
            EntityCollision2DProxy proxy = render.gameObject.AddComponent<EntityCollision2DProxy>();
            proxy.entity = entity;
            collider = render.gameObject.AddComponent<BoxCollider2D>();
        }
        else
        {
            Debug.LogError("You cannnot add entity collider without render component");
        }
    }

    public void SetColliderBox(Vector2 colliderBox)
    {
        collider.size = colliderBox;
    }

    public void SetColliderCenter(Vector2 center)
    {
        collider.offset = center;
    }

    public void SetRigidBody()
    {
        if(entity.HasComponent<RenderComponent>())
        {
            var render = entity.GetComponent<RenderComponent>();
            Rigidbody2D = render.gameObject.AddComponent<Rigidbody2D>();
            Rigidbody2D.freezeRotation = true;
        }
        else
        {
            Debug.LogError("You cannot add entity rigidbody without render component");
        }
    }
}
