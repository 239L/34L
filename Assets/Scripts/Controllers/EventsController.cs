using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
    public class EventsController : MonoBehaviour

    {
        public static EventsController instance;

        [SerializeField]
        private ScriptableGameData sc;
        [SerializeField]
        private VoidEvent onWireCut;
        [SerializeField]
        private VoidEvent onButtonPressed;
        [SerializeField] BoolEvent hideEvent;

        [SerializeField] VoidEvent onSet;
        [SerializeField] VoidEvent onWrong;
        [SerializeField] VoidEvent onGemTaking;
        [SerializeField] VoidEvent onGiftOpen;

    [SerializeField] GameObject minigame_panel;

    private Interactable currentInteractable;

        [SerializeField]
        private List<BoolValue> eventsValues = new List<BoolValue>();
        public Interactable CurrentInteractable { get => currentInteractable; }
        [SerializeField]Player player;

        static bool toPerform=true;

        [SerializeField]GameObject[] locks;

        
        [SerializeField]
        GameObject yellowGem;
        [SerializeField]
        GameObject redGem;
        [SerializeField]
        GameObject bronzeKey;
        [SerializeField]
        GameObject goldenKey;
        [SerializeField] GameObject silverKey;
    static bool boxes = false;
    static bool faces = false;

    public static bool minigame_icon_pressed = false;
        public Player Player { get { return player; } set { player = value; } }
        private void Awake()
        {

            if (instance == null)
            { instance = this; }
            else Destroy(gameObject);

            
            if(!sc)sc = GetComponent<ScriptableGameData>();
        
           
        }
        void Start()
        {
        
        }
    void Update()
    {
        
    }

    public void pressMinigameIcon() {
        minigame_icon_pressed = true;
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

    public void setComputerBool() {
        if (!minigame_icon_pressed||(ComputerGameEMU.start_trigger&&minigame_icon_pressed)) { eventsValues[19].value = false; }
        
    }

    public void setGoldenKeyBool() {
        eventsValues[20].value = true;
        goldenKey.SetActive(true);
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
                        else { a = new Color(1f, 1f, 1f, 0f); SaveSystem.SaveGameData(sc); }
                         
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
            case ComputerInteract comp:if (!comp.Comp.value) { comp.Comp.value = true; minigame_panel.SetActive(true);player.Freeze(); } break;
            case KeyInteract keyInt:
                if (interactable.Interact.getBool().value)
                {
                    switch (keyInt.KeyType.Name)
                    {
                        case "Golden": goldenKey.SetActive(false); break;
                        case "Silver": silverKey.SetActive(false); break;
                        case "Bronze": bronzeKey.SetActive(false); break;
                    }
                    break;
                }break;
            case DoorInteract door:
                if (!interactable.Interact.getBool().value)
                {
                    bool all = true;
                    for (int i = 0; i < locks.Length; i++)
                    {
                        if (locks[i].activeSelf) { all = false; break; }
                    }
                    if (all) { door.Unlock.value = true; player.cantMove = true; SceneController.instance.LoadScene((int)SceneIndexes.ENDING); }
                    else
                    {
                        SoundController.playSE(SE.CLICK);
                        bool[] keys = new bool[3];
                        keys[0] = eventsValues[23].value;
                        keys[1] = eventsValues[24].value;
                        keys[2] = eventsValues[25].value;
                        for (int i = 0; i < keys.Length; i++)
                        {
                            if (keys[i]) { locks[i].SetActive(false); }
                        }
                    }
                }
                
                break;
            case GiftInteract gift: if (!interactable.Interact.getBool().value) {
                    gift.Gift.value=true;
                    
                    
                    onGiftOpen.Raise();
                }break;
            case AbyssInteract abyss:
                if (interactable.Interact.getBool().value) {
                    player.cantMove = true;
                    interactable.enabled = false;
                    player.Fall();

                }
                break;
            case MimicInteract mimic:
                if (interactable.Interact.getBool().value) {
                    SoundController.playME(ME.SLICE);
                    SceneController.instance.LoadScene((int)SceneIndexes.GAMEOVER);
                    interactable.enabled = false;
                }break;
            default:break;

        }
            


        }


    }
