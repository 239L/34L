using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.GameEvents.Events;
using NearYouNameSpace.World;
using NearYouNameSpace.ScriptableObjects;


namespace NearYouNameSpace.Controllers
{
    public class EventsController : MonoBehaviour

    {
        public static EventsController instance;

        [SerializeField]
        private VoidEvent onWireCut;
        [SerializeField]
        private VoidEvent onButtonPressed;

        private Interactable currentInteractable;

        [SerializeField]
        private List<BoolValue> eventsValues = new List<BoolValue>();
        public Interactable CurrentInteractable { get => currentInteractable; }

        private void Awake()
        {

            if (instance == null)
            { instance = this; }
            else Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
        void Start()
        {

        }



        void Update()
        {

        }

        public void playEvent(Interactable interactable)
        {

            if (interactable.Interact.getBool().value)
            {
                switch (interactable.Interact)
                {

                    case AxeInteract axe: Destroy(interactable.gameObject); break;
                    case WireInteract wires:
                        if (eventsValues[0].value) //AxeTouched
                        {
                            int size = interactable.transform.childCount;
                            if (size == 1)
                            {
                                Destroy(interactable.gameObject);
                            }
                            else
                            {
                                for (int i = size - 1; i >= 0; i--)
                                {
                                    if (i != 0 && i != size - 1) { Destroy(interactable.GetComponentInChildren<Transform>().GetChild(i).gameObject); }

                                }
                            }
                            currentInteractable = interactable;
                            onWireCut.Raise();
                        }
                        else { interactable.Interact.setBool(false); }
                        break;
                    case RedButtonInteract red: onButtonPressed.Raise(); break;


                }
            }


        }


    }
}