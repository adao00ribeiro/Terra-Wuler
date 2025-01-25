using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerraWuler
{
        public class SpawnerEnemyManager : MonoBehaviour
    {

        [Header("Settings")]
        public int maxActiveEnemies = 10; 
        private int currentEnemyCount = 0;


        public bool CanSpawn()
        {
            return currentEnemyCount < maxActiveEnemies;
        }

        public void OnEnemySpawned()
        {
            currentEnemyCount++;
        }

        public void OnEnemyDestroyed()
        {
            currentEnemyCount--;
        }
    }
}
