using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    void OnInteract(Inventory inventory);
    void StartFocus();
    void EndFocus();
    string GetTitle();
} 