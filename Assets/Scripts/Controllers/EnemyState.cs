using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum AIState { 
        idle,
        noticed,
        lost,
        wandering,
        outofrange,
        pursuing,
        onTrack
    }
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyStates", fileName = "New EnemyState")]
    public class EnemyState : ScriptableObject
    {
        [SerializeField]
        AIState state = AIState.idle;

        public AIState getState()
        {
            return state;
        }
        public void changeState(AIState state)
        {
            if (this.state != state)
            {
                this.state = state;
            }
        }
    }
