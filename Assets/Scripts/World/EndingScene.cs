using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void backToMenu() {
        SceneController.instance.LoadScene((int)SceneIndexes.MENU);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
