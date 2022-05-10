using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClick : MonoBehaviour
{
    [SerializeField] ComputerGameEMU gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameController.Moves[int.Parse(name)] == 0) {
            gameController.Me = int.Parse(name);
            gameController.performMove();
            gameController.Time_To_Think = Random.Range(1f,3f);
        }
    }

}
