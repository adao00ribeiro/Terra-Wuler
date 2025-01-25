using System;
using TerraWuler;
using UnityEngine;
public class GameController : MonoBehaviour
{
    [Header("Prefab Managers")]
    [SerializeField] private GameObject[] ObjectsManager;
 
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        ObjectsManager = Resources.LoadAll<GameObject>("Prefabs/Managers");
        InitManagers();
        DontDestroyOnLoad(this);
    }
    public void InitManagers()
    {
        foreach (var item in ObjectsManager)
        {
            Instantiate(item, transform);
        }
    }

    public T GetComponentManager<T>() where T : class
    {
       
        foreach (var item in ObjectsManager)
        {
            if (item.TryGetComponent<T>(out var component))
            {
                return component;
            }
        }
        return default;
    }
    private static GameController _instance;

    public static GameController Instance
    {
        get
        {

            return _instance;
        }
    }

}
