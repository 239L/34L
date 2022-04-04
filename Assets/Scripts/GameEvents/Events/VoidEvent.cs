using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.GameEvents;
namespace NearYouNameSpace.GameEvents.Events
{
    [CreateAssetMenu(fileName = "New Void Event", menuName = "Game Events/VoidEvent")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}