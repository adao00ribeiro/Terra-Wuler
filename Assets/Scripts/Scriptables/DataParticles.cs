using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Particles", order = 1)]
public class DataParticles : ScriptableObject
{
    public string Name;
    public ParticleSystem Particles;

}
