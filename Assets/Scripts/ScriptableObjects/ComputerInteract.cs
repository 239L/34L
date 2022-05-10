using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Interact/ComputerInteract", fileName = "New Computer Interact")]
public class ComputerInteract : Interact
{
    [SerializeField]
    BoolValue comp;

    public BoolValue Comp { get => comp; set => comp = value; }

    public override BoolValue getBool()
    {
        return comp;
    }



}
