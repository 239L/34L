using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearYouNameSpace.GameEvents.EventListeners
{
    public interface IEventListener<T>
    {
        void OnEventRaised(T item);
    }
}