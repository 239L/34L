using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearYouNameSpace.GameInterface
{
    public class Pause : MonoBehaviour
    {
        
        public static bool isPaused = false;
        [SerializeField]
        GameObject menuPanel;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();
                }
                else {
                    PauseMenu();
                }
            }

        }

        void Resume() {
            
            menuPanel.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        void PauseMenu() {
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
}