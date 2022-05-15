using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Interact/AbyssInteract", fileName = "New Abyss Interact")]
public class AbyssInteract : Interact
{
    [SerializeField]
    BoolValue abyssTouched;

    public BoolValue AbyssTouched { get => abyssTouched; set => abyssTouched = value; }

    public override BoolValue getBool()
    {
        return abyssTouched;
    }

    public override void setBool(bool b)
    {
        abyssTouched.value = b;
    }
    public override void Act()
    {
        if (!abyssTouched.value) abyssTouched.value = true;

    }

}
