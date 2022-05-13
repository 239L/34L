using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenuTrigger : MonoBehaviour
{
    bool toLeave = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeScene() {
        toLeave = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey&&toLeave) {
            SceneController.instance.LoadScene((int)SceneIndexes.MENU);
        }
    }
}
