using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.ScriptableObjects;
using NearYouNameSpace.Player;
public class Unhide : MonoBehaviour
{
    [SerializeField]
    BoolValue hide;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hide.value) {
            StartCoroutine(waitToPress());
        }
    }

    IEnumerator waitToPress() {
        yield return new WaitForSeconds(1f);
        StartCoroutine(returnControl());
    }
    IEnumerator returnControl() {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.E));
        hide.value = false;
        Color a = new Color(1f, 1f, 1f, 1f);
        FindObjectOfType<Player>().gameObject.GetComponent<SpriteRenderer>().material.color = a;
        
    }
}
