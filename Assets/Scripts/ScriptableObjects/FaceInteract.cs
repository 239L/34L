using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(menuName = "ScriptableObjects/Interact/FaceInteract", fileName = "New Face Interact")]
public class FaceInteract : Interact
{
    [SerializeField]
    BoolValue faceOn;

    [SerializeField] BoolValue []faces;

    public BoolValue[] Faces { get => faces; set => faces=value; }


    [SerializeField]
    int number;

    public int Number { get => number; }

    
    public BoolValue FaceOn { get => faceOn; set => faceOn = value; }

    public override BoolValue getBool()
    {
        return faceOn;
    }

    public void nullifyFaces() {
        for (int i = 0; i < faces.Length; i++)
        {
            faces[i].value = false;
        }
    }
    

    
}
