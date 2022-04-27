using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ManagementHelper : MonoBehaviour
    {
        private void Awake()
        {
            if (GameResolution.instance == null)
            {

                Instantiate(Resources.Load("Resolution"));

            }

            if (SceneController.instance == null)
            {
                Instantiate(Resources.Load("SceneManager"));
            }
            if (LocalizationController.Instance == null)
            {
                Instantiate(Resources.Load("Localization"));
            }
            if (SoundAssets.Instance == null) {
                Instantiate(Resources.Load("SoundAssets"));
            }
            if (ScriptableConfig.Instance == null) {
                Instantiate(Resources.Load("ConfigData"));
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
