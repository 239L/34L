using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Interact/GiftInteract", fileName = "New Gift Interact")]
public class GiftInteract : Interact
{
    [SerializeField]
    BoolValue gift;


    public BoolValue Gift { get => gift; set => gift = value; }

    public override BoolValue getBool()
    {
        return gift;
    }
    public override void Act()
    {

        
    }
}
