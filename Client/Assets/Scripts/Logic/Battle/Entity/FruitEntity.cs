using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitEntity : Entity
{
    public FruitEntity() 
    {
        this.AddComponent<PositionComponent>(new PositionComponent());
        this.AddComponent<RenderComponent>(new RenderComponent());
    }
}
