using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Manager<ResourcesManager>
{
    private ResourcesManager() { }
    private const string prefabFolderName = "UI/Prefabs/";

    public GameObject LoadPrefab(string path)
    {
        path = prefabFolderName + path;
        GameObject gameObject = Resources.Load<GameObject>(path);
        if(gameObject == null)
        {
            Debug.LogError("LoadPrefab failed, path: " + path);
            return null;
        }
        return gameObject;
    }
}
