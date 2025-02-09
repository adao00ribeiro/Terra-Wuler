using System;
using TerraWuler;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private DataAudio[] dataAudios;
    [SerializeField] private DataCharacter[] dataCharacters;
    [SerializeField] private DataParticles[] dataParticles;
    [SerializeField] private DataDecals[] dataDecals;
    [SerializeField] private DataEnemy[] dataEnemy;
    [SerializeField] private DataItem[] dataItems;

    void Start()
    {

        dataItems = Resources.LoadAll<DataItem>("Datas/WorldItems");
        dataCharacters = Resources.LoadAll<DataCharacter>("Datas/Characters");
        dataAudios = Resources.LoadAll<DataAudio>("Datas/DataAudios");
        dataParticles = Resources.LoadAll<DataParticles>("Datas/DataParticles");
        dataDecals = Resources.LoadAll<DataDecals>("Datas/DataDecals");
    }

    public DataItem GetDataItemById(string guidId)
    {
        DataItem temp = null;
        foreach (DataItem item in dataItems)
        {
            if (item.GuidId == guidId)
            {
                temp = item;
            }
        }
        return temp;
    }
    public DataCharacter GetDataCharacterByName(string name)
    {
        DataCharacter temp = null;
        foreach (DataCharacter item in dataCharacters)
        {
            if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                temp = item;
            }
        }
        return temp;
    }

    internal DataItem GetDataItemByName(string name)
    {
        DataItem temp = null;
        foreach (DataItem item in dataItems)
        {
            if (item.Name == name)
            {
                temp = item;
            }
        }
        return temp;
    }
}