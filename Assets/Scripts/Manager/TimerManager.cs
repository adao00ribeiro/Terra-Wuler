using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TerraWuler
{
    public class TimerManager : MonoBehaviour
    {
        private static TimerManager _instance;
        public static TimerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    var obj = new GameObject("TimerManager");
                    _instance = obj.AddComponent<TimerManager>();
                    DontDestroyOnLoad(obj);
                }
                return _instance;
            }
        }

        [System.Serializable]
        public class TimedEvent
        {
            public float TriggerTime;
            public Action Method;
        }

        private List<TimedEvent> timedEvents;


        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                timedEvents = new List<TimedEvent>();
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        public void AddEvent(float timeInSeconds, Action method)
        {
            timedEvents.Add(new TimedEvent
            {
                TriggerTime = Time.time + timeInSeconds,
                Method = method
            });
        }

        private void Update()
        {
            float currentTime = Time.time;

            for (int i = timedEvents.Count - 1; i >= 0; i--)
            {
                if (currentTime >= timedEvents[i].TriggerTime)
                {
                    timedEvents[i].Method();
                    timedEvents.RemoveAt(i);
                }
            }
        }
    }
}