public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static T Instance
    {
        get{
            if(_instance == null)
            {
                _instance == FindObjectOfType<T>();
                if(_instance == null)
                {
                    GameObject singleObject = new GameObject(typeof(T).Name);
                    _instance = singleObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Init()
    {

    }
}