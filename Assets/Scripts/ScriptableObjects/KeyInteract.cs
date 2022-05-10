using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Interact/KeyInteract", fileName = "New Key Interact")]
public class KeyInteract : Interact
{
    [SerializeField]
    BoolValue keyTaken;

    [SerializeField] EnumValue keyType;

    public EnumValue KeyType { get => keyType; }

    public BoolValue KeyTaken { get => keyTaken; set => keyTaken = value; }

    public override BoolValue getBool()
    {
        return keyTaken;
    }
    public override void Act()
    {
        if (!keyTaken.value) { keyTaken.value = true; }

    }
}
