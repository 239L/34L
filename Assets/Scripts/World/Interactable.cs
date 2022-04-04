using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.ScriptableObjects;
using NearYouNameSpace.GameEvents.Events;
namespace NearYouNameSpace.World
{
    public class Interactable : MonoBehaviour
    {
        bool isTriggered = false;
        bool Finished = false;
        [SerializeField]
        Interact interact;
        public Interact Interact { get => interact; set => interact = value; }

        [SerializeField]
        EnumValue type;
        public EnumValue Type { get => type; }


        [SerializeField]
        InteractableEvent onInteract;



        private void Awake()
        {

        }
        // Start is called before the first frame update
        void Start()
        {
            if (Type) onInteract.Raise(this);

        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerEnter2D(Collider2D collision)
        {

        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Player"))
            {
                Debug.Log("Interact");
                Interact.Act();
                onInteract.Raise(this);

            }
        }


    }
}