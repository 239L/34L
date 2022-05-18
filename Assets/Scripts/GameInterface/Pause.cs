using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Pause : MonoBehaviour
    {
        public static bool canPause = true;
        public static bool isPaused = false;

    [SerializeField] GameObject computer;
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
            if (canPause&&!computer.activeSelf)
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
            if (SoundAssets.Instance.BGSSource.clip)
            {
                SoundAssets.Instance.BGSSource.UnPause();
            }
            isPaused = false;
        }

        void PauseMenu() {
            
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
            if (SoundAssets.Instance.BGSSource.clip)
            {
                SoundAssets.Instance.BGSSource.Pause();
            }
            isPaused = true;
        }
    }
