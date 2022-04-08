using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.GameData;
namespace NearYouNameSpace.GameInterface
{
    public class Pause : MonoBehaviour
    {
        public static bool canPause = true;
        public static bool isPaused = false;
        [SerializeField]
        GameObject menuPanel;

        [SerializeField]
        ScriptableConfig sc;
        // Start is called before the first frame update
        void Start()
        {
            sc = FindObjectOfType<ScriptableConfig>();
            canPause = true;
            Time.timeScale = 1f; 
            isPaused = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (canPause)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (isPaused)
                    {
                        Resume();
                    }
                    else
                    {
                        PauseMenu();
                    }
                }
            }

        }

        void Resume() {

            SaveSystem.SaveConfigData(sc);
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