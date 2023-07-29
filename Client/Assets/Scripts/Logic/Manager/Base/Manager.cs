using UnityEngine;

public interface IManager
{
    void Initialize();
}

public class Manager<T> : MonoBehaviour, IManager where T : Manager<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = GameObject.Find("Managers");
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        // Add initialization logic here
    }
}