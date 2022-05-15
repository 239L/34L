using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public float playerPosX;
    public float playerPosY;
    public bool axe;
    public bool wire1, wire2, wire3, wire4;
    public bool redbutton;
    public bool box1, box2, box3, box4;
    public bool face1, face2, face3, face4,face5;
    public bool redgem, greengem, yellowgem;
    public bool computer;
    public bool goldenkey, silverkey, bronzekey;
    public bool goldenkeyTaken, silverkeyTaken, bronzekeyTaken;
    public bool door_unlocked;
    public bool abyss, mimic;

    public GameData(ScriptableGameData sc) {
        playerPosX = sc.PlayerPos.pos.x;
        playerPosY = sc.PlayerPos.pos.y;
        axe = sc.EventValues[0].value;
        wire1 = sc.EventValues[1].value;
        wire2 = sc.EventValues[2].value;
        wire3 = sc.EventValues[3].value;
        wire4 = sc.EventValues[4].value;
        redbutton = sc.EventValues[5].value;
        box1 = sc.EventValues[6].value;
        box2 = sc.EventValues[7].value;
        box3 = sc.EventValues[8].value;
        box4 = sc.EventValues[9].value;
        face1 = sc.EventValues[10].value;
        face2 = sc.EventValues[11].value;
        face3 = sc.EventValues[12].value;
        face4 = sc.EventValues[13].value;
        face5 = sc.EventValues[14].value;
        greengem = sc.EventValues[15].value;
        redgem = sc.EventValues[16].value;
        yellowgem = sc.EventValues[17].value;
        computer = sc.EventValues[18].value;
        goldenkey = sc.EventValues[19].value;
        bronzekey = sc.EventValues[20].value;
        silverkey = sc.EventValues[21].value;
        goldenkeyTaken = sc.EventValues[22].value;
        bronzekeyTaken = sc.EventValues[23].value;
        silverkeyTaken = sc.EventValues[24].value;
        door_unlocked = sc.EventValues[25].value;
        abyss = false;
        mimic = false;
    }
  
}
