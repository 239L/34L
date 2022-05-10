using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Interact/DoorInteract", fileName = "New Door Interact")]
public class DoorInteract : Interact
{
    [SerializeField]
    BoolValue unlock;


    public BoolValue Unlock { get => unlock; set => unlock = value; }

    public override BoolValue getBool()
    {
        return unlock;
    }
    public override void Act()
    {
       

    }
}
