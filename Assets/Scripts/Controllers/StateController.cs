using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearYouNameSpace.Controllers
{
    public enum State
    {
        idle,
        move,
        run,
        runcooldown
    }
    [CreateAssetMenu(menuName = "ScriptableObjects/States", fileName = "New State")]
    public class StateController : ScriptableObject
    {
        [SerializeField]
        State state = State.idle;

        public State getState()
        {
            return state;
        }
        public void changeState(State state)
        {
            if (this.state != state)
            {
                this.state = state;
            }
        }

    }
}