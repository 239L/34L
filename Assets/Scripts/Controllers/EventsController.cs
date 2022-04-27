using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        [SerializeField]Player player;

        static bool toPerform=true;

        [SerializeField]
        GameObject yellowGem;

    static bool boxes = false;
        public Player Player { get { return player; } set { player = value; } }
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
        if (eventsValues[7].value && eventsValues[8].value && eventsValues[9].value && eventsValues[10].value&&!boxes) {
            SoundController.playME(ME.EVENT);
            yellowGem.SetActive(true);
            boxes = true;

        }
    }

    public static void setPerformed(bool perform) {
        toPerform = perform;
    }

        public void onSceneChanged(int index) {
            if (index > 0) {
                eventsValues[6].value = false; //hidingspot trigger
               
            }

        }

    
        IEnumerator waitForTheClosetToOpen(Color a) {
            yield return new WaitUntil(() => !HidingSpotController.performed);
            player.gameObject.GetComponent<SpriteRenderer>().material.color = a;
            toPerform = false;
        }

   
        public void playEvent(Interactable interactable)
        {

            
                switch (interactable.Interact)
                {

                    case AxeInteract axe:
                        if (interactable.Interact.getBool().value)
                        {
                            Destroy(interactable.gameObject);

                        }
                        break;
                    case WireInteract wires:
                        if (interactable.Interact.getBool().value)
                        {
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
                        }
                        break;
                    case RedButtonInteract red:
                        if (interactable.Interact.getBool().value)
                        {
                            onButtonPressed.Raise();
                        }
                        break;
                        
                    case HidingSpotInteract hd:
                        Debug.Log(toPerform);
                        currentInteractable = interactable;
                        if (toPerform)
                        {
                    
                    player.cantMove = interactable.Interact.getBool().value;
                        Debug.Log(player.cantMove);
                        Color a;
                        
                        if (!player.cantMove)
                        {
                            a = new Color(1f, 1f, 1f, 1f);
                        }
                        else { a = new Color(1f, 1f, 1f, 0f); }
                         
                         StartCoroutine(waitForTheClosetToOpen(a));
                        }
                        break;
                }
            


        }


    }
