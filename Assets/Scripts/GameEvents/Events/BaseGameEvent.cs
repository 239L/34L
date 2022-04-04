using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.GameEvents.EventListeners;
namespace NearYouNameSpace.GameEvents.Events
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IEventListener<T>> eventListeners = new List<IEventListener<T>>();

        public void Raise(T item)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised(item);
            }
        }

        public void RegisterListener(IEventListener<T> listener)
        {

            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }
        public void UnRegisterListener(IEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }
    }
}