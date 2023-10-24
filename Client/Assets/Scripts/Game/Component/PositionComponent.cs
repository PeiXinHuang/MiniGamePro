using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionComponent : BaseComponent
{
    private float x, y, z;
    public PositionComponent() { }
    public PositionComponent(float x, float y, float z)
    {
        SetPosition(x, y, z);
    }
    public void SetPosition(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector3 GetPosition()
    {
        return new Vector3(x, y, z);
    }
}
