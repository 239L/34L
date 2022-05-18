using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject slot;
    [SerializeField]
    GemInteract interact;
    [SerializeField] Interactable interactable;
    public void placeInTheSlot() {
        if (interact.getBool().value)
        {
            transform.position = slot.transform.position;
            GetComponentInParent<SpriteRenderer>().sortingOrder = 4;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
