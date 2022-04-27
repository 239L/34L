using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    public abstract class BasicEventListener<T, E, UER> : MonoBehaviour, IEventListener<T>
        where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] private E gameEvent;

        public E GameEvent { get => gameEvent; set => gameEvent = value; }

        [SerializeField] private UER response;

        void OnEnable()
        {
            if (gameEvent == null) { return; }

            GameEvent.RegisterListener(this);
        }

        void OnDisable()
        {
            if (gameEvent == null) { return; }

            GameEvent.UnRegisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            if (response != null)
            {
                response.Invoke(item);
            }
        }
    }
