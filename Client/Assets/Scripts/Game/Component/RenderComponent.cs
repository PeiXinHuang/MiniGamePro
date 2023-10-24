using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderComponent : BaseComponent
{
    //todo: gameobjct modify to unity proxy
    public GameObject gameObject;
    public RenderComponent()
    {

    }
    public override void Init(Entity entity)
    {
        base.Init(entity);
        if(!entity.HasComponent<TransformComponent>())
        {
            Debug.LogError("You cannnot add renderComponent to entity which without TransformComponent");
        }
    }

    public void InitGameObject(string path, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if(prefab != null)
        {
            if(parent != null)
            {
                gameObject = GameObject.Instantice<GameObject>(prefab, parent);
            }
            else
            {
                gameObject = GameObject.Instantice<GameObject>(prefab);
            }
        }
        else
        {
            Debug.LogWarning("Init GameObejct fail " + path);
        }
    }

    public void SetRenderPos(Vector3 pos)
    {
        if(gameObject != null)
        {
            gameObject.transform.position = pos;
        }
    }
    public override void Dispose()
    {
        GameObject.Destroy(this.gameObject);
    }
}
