using System;
using TerraWuler;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private DataAudio[] dataAudios;
    // [SerializeField] private DataCharacter[] dataCharacter;
    [SerializeField] private DataDecals[] dataDecals;
    [SerializeField] private DataEnemy[] dataEnemy;
    [SerializeField] private DataItem[] dataItems;
  
    void Start()
    {
  
            dataItems = Resources.LoadAll<DataItem>("Datas/DataItems");
            //ListChareacter = Resources.LoadAll<DataCharacter>("Datas/DataCharacters");
            dataAudios = Resources.LoadAll<DataAudio>("Datas/DataAudios");
           // ListParticles = Resources.LoadAll<DataParticles>("Datas/DataParticles");
            dataDecals = Resources.LoadAll<DataDecals>("Datas/DataDecals");
    }

      internal DataItem GetDataItemById(string guidId)
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
}