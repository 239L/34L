using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Interactable : MonoBehaviour
    {
        bool isTriggered = false;
        bool Finished = false;
        [SerializeField]
        Interact interact;
        public Interact Interact { get => interact; set => interact = value; }

        [SerializeField]
        EnumValue type;

        [SerializeField]
        int number;

        public int Number { get { return number; } }
        public EnumValue Type { get => type; }

        [SerializeField] InteractingNumber compareNumber;
        

        [SerializeField]
        InteractableEvent onInteract;

        bool triggered = false;
        
        private void Awake()
        {
            if (EventsController.instance) { if (!EventsController.instance.Player) { EventsController.instance.Player = FindObjectOfType<Player>(); } }
        }
        // Start is called before the first frame update
        void Start()
        {
           
            if (Type&&Type.Name!="Hide"&&Type.Name!="Face") onInteract.Raise(this);
            triggered = false;

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && triggered)
            {
                //if (!compareNumber || compareNumber.Number == number)
                //{
                    Debug.Log("Interact");
                    Interact.Act();
                    onInteract.Raise(this);
                //}

            }
        }



        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                triggered = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                triggered = true;
            }

        }


        private void OnTriggerStay2D(Collider2D collision)
        {
           
        }


    }
