using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    void OnInteract(Character character);
    void StartFocus();
    void EndFocus();
    string GetTitle();
} 