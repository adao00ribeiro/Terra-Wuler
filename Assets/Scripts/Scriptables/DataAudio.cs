using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataAudio", menuName = "Data/Audio")]
public class DataAudio : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private AudioClip _audio;

    public string Name { get => _name; }
    public AudioClip Audio { get => _audio; }

}


