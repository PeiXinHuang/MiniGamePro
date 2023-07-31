using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ResourcesManager : Manager<ResourcesManager>
{
    private ResourcesManager() { }
    private const string prefabFolderName = "UI/Prefabs/";
    private const string modelFolderName = "Models/";
    private const string altasFolderName = "UI/Altas/";

    public GameObject LoadPrefab(string path)
    {
        path = prefabFolderName + path;
        GameObject gameObject = Resources.Load<GameObject>(path);
        if (gameObject == null)
        {
            Debug.LogError("LoadPrefab failed, path: " + path);
            return null;
        }
        return gameObject;
    }

    public GameObject LoadModel(string path)
    {
        path = modelFolderName + path;
        GameObject gameObject = Resources.Load<GameObject>(path);
        if (gameObject == null)
        {
            Debug.LogError("Load model failed, path: " + path);
            return null;
        }
        return gameObject;
    }

    public SpriteAtlas LoadAltas(string altasName)
    {
        string path = altasFolderName + altasName;
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>(path);
        if (atlas == null)
        {
            Debug.LogError("Load altas failed, path: " + path);
            return null;
        }
        return atlas;
    }
}
