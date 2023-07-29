using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSystem : BaseSystem
{
    public override void Update()
    {
        List<Entity> entities = EntityManager.Instance.GetEntityWithComp<PositionComponent>();
        foreach (var entity in entities)
        {
            Debug.Log(string.Format("{0}Œª÷√‘⁄{1}", entity.entityId.ToString(), entity.GetComponent<PositionComponent>().GetPosition().ToString()));
        }
    }
}
