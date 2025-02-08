using System;
using System.Collections;
using System.Collections.Generic;
using TerraWuler;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public event Action<int, Slot> OnUpdateInventory;
  
    public  List<Slot> inventory = new List<Slot>();
    [SerializeField] private int maxSlot = 6;

    public bool teste;
    void Awake()
    {

    }
    void FixedUpdate()
    {
      
    }
    void Start()
    {
        for (int i = 0; i < maxSlot; i++)
        {
            inventory.Add(new Slot());
        }
    }
 
  
    public Slot GetSlot(int index)
    {
        return inventory[index];
    }
    public bool AddItem(Slot slot)
    {
        DataItem item = GameController.Instance.GetComponentManager<DataManager>().GetDataItemById(slot.GuidId);
        if (item == null)
        {
            return false;
        }

        for (int i = 0; i < maxSlot; i++)
        {
            if (inventory[i].Compare(new Slot()))
            {
                inventory[i] = slot;
                return true;
            }
        }
        return false;
    }

    public void InsertItem(int slotEnterIndex, int slotIndexselecionado)
    {
        Slot auxEnter = inventory[slotEnterIndex];
        inventory[slotEnterIndex] = inventory[slotIndexselecionado];
        inventory[slotIndexselecionado] = auxEnter;
    }

    public void RemoveItem(Slot slot)
    {

        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Compare(slot))
            {
                inventory[i] = new Slot();
            }
        }
    }
   
    

    internal int GetMaxSlots()
    {
        return maxSlot;
    }
    
}