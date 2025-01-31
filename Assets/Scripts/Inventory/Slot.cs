using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Slot 
{
    public string Name;
    public string GuidId;
    public int Quantity;

    public Slot(String none = "None")
    {
        Name = "";
        GuidId = "";
        Quantity = 0;
    }
    public Slot(string _name, string _guidid, int _ammo, int _Quantity)
    {
        Name = _name;
        GuidId = _guidid;
        Quantity = _Quantity;
    }
    public bool Compare(Slot other)
    {
        if (Name == other.Name && GuidId == other.GuidId && Quantity == other.Quantity)
        {
            return true;
        }

        return false;
    }
}
