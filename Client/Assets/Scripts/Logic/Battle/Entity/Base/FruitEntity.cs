using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitEntity : Entity
{
    GameObject gameObject = null;
    public FruitEntity() 
    {
        this.AddComponent<PositionComponent>(new PositionComponent());
        gameObject = SpawnManager.Instance.SpawnFruitObj(1);
        WorldObjHelper worldObj = gameObject.AddComponent<WorldObjHelper>();
        worldObj.uid = entityId;
    }

    public override void Destroy()
    {
        base.Destroy();
        if (gameObject != null)
        {
            GameObject.Destroy(gameObject);
            gameObject = null;
        }
    }
}
