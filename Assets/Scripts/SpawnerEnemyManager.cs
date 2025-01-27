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

        void Start(){
           DataManager DATA =  GameController.Instance.GetComponentManager<DataManager>();
           InputManager input =  GameController.Instance.GetComponentManager<InputManager>();
        }
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
