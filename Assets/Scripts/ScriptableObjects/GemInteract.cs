using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Interact/GemInteract", fileName = "New Gem Interact")]
public class GemInteract : Interact
{
    [SerializeField]
    BoolValue gemTaken;



    public BoolValue GemTaken { get => gemTaken; set => gemTaken = value; }

    public override BoolValue getBool()
    {
        return gemTaken;
    }
    public override void Act()
    {
        if (!gemTaken.value) { gemTaken.value = true; }

    }
}
