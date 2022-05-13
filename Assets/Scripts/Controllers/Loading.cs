using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField]
    GameObject loadingPanel;
    void Start()
    {
        
    }

    public void makeVisible() {
        loadingPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
