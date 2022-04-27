
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    [SerializeField]
    string objectName;


    public virtual BoolValue getBool() { return new BoolValue(); }

    public virtual void setBool(bool b) { }
    public virtual void Act() { }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
