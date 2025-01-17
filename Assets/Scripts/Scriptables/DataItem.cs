using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerraWuler
{
    [CreateAssetMenu(fileName = "DataItem", menuName = "Data/Item", order = 1)]
    public class DataItem : ScriptableObject
    {
        [SerializeField] public string GuidId;
        //[SerializeField] public ItemType Type;
        [SerializeField] public string Name;
        [SerializeField] public string Description = "NONE";
        [SerializeField] public float Durability;
        [SerializeField] public bool Stackble;
        [SerializeField] public GameObject Prefab;


        public DataItem()
        {
            this.GuidId = System.Guid.NewGuid().ToString();
            //this.Type = ItemType.none;
            this.Name = "NONE";
            this.Description = "NONE";
            this.Durability = 0.0f;
            this.Prefab = null;
        }
    }
}
