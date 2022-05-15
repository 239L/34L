using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableGameData : MonoBehaviour
{
    private static ScriptableGameData instance;
    public static ScriptableGameData Instance { get => instance; }
    void Start()
    {
        if (instance == null) { instance = this; }
        DontDestroyOnLoad(this);
        loadGameData(SaveSystem.LoadGameData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGameData(GameData data) {
        if (data != null) {
            playerpos.pos=new Vector2(data.playerPosX,data.playerPosY);
            eventValues[0].value=data.axe;
            eventValues[1].value=data.wire1;
            eventValues[2].value=data.wire2;
            eventValues[3].value=data.wire3;
            eventValues[4].value=data.wire4;
            eventValues[5].value=data.redbutton;
            eventValues[6].value=data.box1;
            eventValues[7].value=data.box2;
            eventValues[8].value=data.box3;
            eventValues[9].value=data.box4;
            eventValues[10].value=data.face1;
            eventValues[11].value=data.face2;
            eventValues[12].value=data.face3;
            eventValues[13].value=data.face4;
            eventValues[14].value=data.face5;
            eventValues[15].value=data.greengem;
            eventValues[16].value=data.redgem;
            eventValues[17].value=data.yellowgem;
            eventValues[18].value=data.computer;
            eventValues[19].value=data.goldenkey;
            eventValues[20].value=data.bronzekey;
            eventValues[21].value=data.silverkey;
            eventValues[22].value=data.goldenkeyTaken;
            eventValues[23].value=data.bronzekeyTaken;
            eventValues[24].value=data.silverkeyTaken;
            eventValues[25].value=data.door_unlocked;
            eventValues[26].value = data.abyss;
            eventValues[27].value = data.mimic;
        }
    }

    [SerializeField] Vector2Value playerpos;
    public Vector2Value PlayerPos { get => playerpos; set => playerpos = value; }
    [SerializeField] BoolValue[] eventValues;

    public BoolValue[] EventValues { get => eventValues; set => eventValues = value; }
}
