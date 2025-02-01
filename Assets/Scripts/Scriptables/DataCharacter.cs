using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCharacter", menuName = "Data/Character")]
public class DataCharacter : ScriptableObject 
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _avatar;
    [SerializeField] private GameObject _prefabCharacter;

    public string Name { get => _name; }
    public Sprite Avatar { get => _avatar; }
    public GameObject PrefabCharacter { get => _prefabCharacter; }
}