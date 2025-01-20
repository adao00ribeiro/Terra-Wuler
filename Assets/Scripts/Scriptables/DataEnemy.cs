using UnityEngine;

public enum TypeEnemy
{    DEFAULT
}
[CreateAssetMenu(fileName = "DataEnemy", menuName = "Data/Enemy")]
public class DataEnemy : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private TypeEnemy _type;
    [SerializeField] private GameObject _prefab;

    public string Name {get => _name;}
    public TypeEnemy Type   {get => _type;}
    public GameObject Prefab {get => _prefab;}



}
