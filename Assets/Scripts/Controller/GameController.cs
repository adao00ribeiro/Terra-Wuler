using System;
using System.Collections.Generic;
using TerraWuler;
using UnityEngine;
public class GameController : MonoBehaviour
{
    [Header("Prefab Managers")]
    [SerializeField] private GameObject[] ObjectsManager;
    private List<GameObject> Managers = new List<GameObject>();
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
            Managers.Add(Instantiate(item, transform));
        }
    }

    public T GetComponentManager<T>() where T : class
    {

        foreach (var item in Managers)
        {
            if (item.TryGetComponent<T>(out T component))
            {
                return component;
            }
        }
        return default;
    }
    private static GameController _instance;
    private PlayerController playerController;
    public static GameController Instance
    {
        get
        {

            return _instance;
        }
    }

    public PlayerController PlayerController
    {
        get
        {
            if (playerController == null)
            {
                playerController = GameObject.FindAnyObjectByType<PlayerController>();
            }
            return playerController;
        }
    }
}
