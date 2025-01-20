using System.Collections.Generic;
using UnityEngine;
using System;

namespace TerraWuler
{
    public class TimerManager : MonoBehaviour
    {
        [System.Serializable]
        public class TimedEvent
        {
            public float TriggerTime;
            public Action Method;
        }

        private List<TimedEvent> timedEvents;

        private void Awake()
        {
            timedEvents = new List<TimedEvent>();
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
            if (timedEvents.Count == 0)
            return;
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