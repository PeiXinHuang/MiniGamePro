using UnityEngine;
public class EntityCollision2DProxy : MonoBahaviour
{
    public Entity entity;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EntityCollision2DProxy otherProxy = collision.gameObject.GetComponent<EntityCollision2DProxy>();
        if(otherProxy != null)
        {
            Entity otherEntity = otherProxy.entity;
            if(otherEntity.HasComponent<ColliderComponent>())
            {
                ColliderEventComponent eventComp = entity.AddComponent<ColliderEventComponent>();
                eventComp.other = otherEntity;
            }
        }
    }
}