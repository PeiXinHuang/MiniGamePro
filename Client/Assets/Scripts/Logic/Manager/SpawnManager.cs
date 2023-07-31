using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : Manager<SpawnManager>
{
    private Transform spawnObjRoot = null;
    public override void Initialize()
    {
        base.Initialize();
        spawnObjRoot = GameObject.Find("ObjRoot").transform;
    }
    public GameObject SpawnFruitObj(int fruitId)
    {
        GameObject prefab = ResourcesManager.Instance.LoadModel("FruitObj");
        GameObject obj = GameObject.Instantiate(prefab);
        obj.transform.SetParent(spawnObjRoot, true);
        SpriteManager.Instance.SetSprite(obj.transform.Find("Icon").GetComponent<SpriteRenderer>(), "Icon_Fruits", fruitId.ToString());
        return obj;
    }
}
