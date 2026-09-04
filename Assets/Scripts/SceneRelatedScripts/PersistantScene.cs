using UnityEngine;

public class PersistantScene : MonoBehaviour
{
    public static PersistantScene Instance;
    //instance only one

    [Header("Persistent Objects")]
    public GameObject[] persistantObjects;
    
    private void Awake()
    {
        if (Instance != null)
        {
            CleanUpAndDestroy();
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistentObjects();
        }
    }

    public void MarkPersistentObjects()
    {
        foreach (GameObject obj in persistantObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    public void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistantObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
