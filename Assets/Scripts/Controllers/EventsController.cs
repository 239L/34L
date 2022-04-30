using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
    public class EventsController : MonoBehaviour

    {
        public static EventsController instance;

        [SerializeField]
        private VoidEvent onWireCut;
        [SerializeField]
        private VoidEvent onButtonPressed;
        [SerializeField] BoolEvent hideEvent;

        [SerializeField] VoidEvent onSet;
        [SerializeField] VoidEvent onWrong;
        [SerializeField] VoidEvent onGemTaking;

    private Interactable currentInteractable;

        [SerializeField]
        private List<BoolValue> eventsValues = new List<BoolValue>();
        public Interactable CurrentInteractable { get => currentInteractable; }
        [SerializeField]Player player;

        static bool toPerform=true;

        [SerializeField]
        GameObject yellowGem;
        [SerializeField]
        GameObject redGem;
        [SerializeField]
        GameObject bronzeKey;

    static bool boxes = false;
    static bool faces = false;
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

    void nullifyFaces() {
        eventsValues[11].value = false;
        eventsValues[12].value = false;
        eventsValues[13].value = false;
        eventsValues[14].value = false;
        eventsValues[15].value = false;
    }

    IEnumerator playEvent() {
        yield return new WaitForSeconds(0.5f);
        SoundController.playME(ME.EVENT);
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
                        hideEvent.Raise(interactable.Interact.getBool().value);
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
                    case BoxInteract box:
                        if (eventsValues[7].value && eventsValues[8].value && eventsValues[9].value && eventsValues[10].value && !boxes)
                        {
                            
                            yellowGem.SetActive(true);
                            boxes = true;
                            StartCoroutine(playEvent());

                        }break;
                    case FaceInteract face: currentInteractable = interactable;
                if (FaceController.animIsFinished)
                {
                    if (!face.FaceOn.value && !faces)
                    {
                        switch (face.Number)
                        {
                            case 5: if (face.Faces.Where(e => e.value == true).Count() <= 0) { face.FaceOn.value = true; onSet.Raise(); } else { nullifyFaces();  onWrong.Raise(); } break;
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            default:
                                if (face.Faces.Where(e => e.value == true).Count() == face.Faces.Length)
                                {
                                    face.FaceOn.value = true;onSet.Raise();
                                }
                                else { nullifyFaces();  onWrong.Raise(); }
                                break;

                        }
                    }
                    
                }
                if (!faces && eventsValues[11].value && eventsValues[12].value && eventsValues[13].value && eventsValues[14].value && eventsValues[15].value)
                    {
                        
                        faces = true;
                    redGem.SetActive(true);
                        StartCoroutine(playEvent());
                    }
                break;
            case GemInteract gem:
                if (interactable.Interact.getBool().value)
                {
                    SoundController.playSE(SE.CLICK);
                    onGemTaking.Raise();
                }
                if (eventsValues[16].value && eventsValues[17].value && eventsValues[18].value) { bronzeKey.SetActive(true);StartCoroutine(playEvent()); }
                break;
                    default:break;

        }
            


        }


    }
