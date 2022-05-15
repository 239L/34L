using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Interact/MimicInteract", fileName = "New Mimic Interact")]
public class MimicInteract : Interact
{
    [SerializeField]
    BoolValue mimicTouched;

    public BoolValue MimicTouched { get => mimicTouched; set => mimicTouched = value; }

    public override BoolValue getBool()
    {
        return mimicTouched;
    }

    public override void setBool(bool b)
    {
        mimicTouched.value = b;
    }
    public override void Act()
    {
        if (!mimicTouched.value) mimicTouched.value = true;

    }
}
