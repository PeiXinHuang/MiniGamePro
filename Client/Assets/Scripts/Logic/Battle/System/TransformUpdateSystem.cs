using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformUpdateSystem : BaseSystem
{
    public override void Update()
    {
        List<Entity> entities = EntityManager.Instance.GetEntityWithComp<PositionComponent>();
        foreach (var entity in entities)
        {
            PositionComponent positionComponent = entity.GetComponent<PositionComponent>();
            Vector3 pos = positionComponent.GetPosition();
            Vector3 newPos = pos + new Vector3(1, 1, 1);
            positionComponent.SetPosition(newPos.x, newPos.y, newPos.z);
        }
    }
}
