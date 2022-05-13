using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public enum SceneIndexes {
        MENU = 0,
        GAME = 1
    }
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private IntValue prevScene;

        [SerializeField] IntEvent intEvent;
        public static SceneController instance;

        [SerializeField]
        GameObject loader;
        
        [SerializeField] VoidEvent fadeOut;
        [SerializeField] VoidEvent fadeIn;
        // Start is called before the first frame update
        void Start()
        {
            findLoader();
            handleBGM();
        }

        void findLoader() {
        if (loader == null) {
            if (GameObject.FindGameObjectWithTag("Loader"))
            {
                loader = GameObject.FindGameObjectWithTag("Loader");
            }
        }
        }
        private void Awake()
        {

            if (instance == null)
            { instance = this; }
            else Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
        // Update is called once per frame
        void Update()
        {

        }

        void handleBGM() {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 0:
                    SoundController.stopBGM();
                    SoundController.playBGM(BGM.MENU, true); break;
                default: SoundController.stopBGM(); SoundController.playBGM(BGM.INGAME, true); break;
            }
        }

        public void LoadScene(int index) {

        if (index == (int)SceneIndexes.GAME)
        {
            intEvent.Raise(index);
        }
            findLoader();
            loader.SetActive(true);
            fadeOut.Raise();
            StartCoroutine(LoadAsyncScene(index));
        }
        IEnumerator LoadAsyncScene(int index)
        {
        
            Debug.Log("Not Loaded");
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
             
                yield return null;
            }
            loader.SetActive(true);
            LocalizationController.Instance.getLocalizedItems();
            handleBGM();
            fadeIn.Raise();
            Debug.Log("Loaded scene");

    }

   
    }
