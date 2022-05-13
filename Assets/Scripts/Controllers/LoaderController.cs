using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderController : MonoBehaviour
{
    [SerializeField]
    public GameObject panel;

    Animator anim;

    public static LoaderController instance;

   

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this); }
        DontDestroyOnLoad(this);
        
        

    }
   

    public void turnOff() {

        panel.SetActive(false);
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
