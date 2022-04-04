using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NearYouNameSpace.AudioManagement;
using NearYouNameSpace.Localization;
using NearYouNameSpace.ScriptableObjects;

namespace NearYouNameSpace.SceneManagement{
    public enum SceneIndexes {
        MENU = 0,
        GAME = 1
    }
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private IntValue prevScene;

        public static SceneController instance;
        // Start is called before the first frame update
        void Start()
        {
            handleBGM();
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
            StartCoroutine(LoadAsyncScene(index));


        }
        IEnumerator LoadAsyncScene(int index)
        {


            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            LocalizationController.Instance.getLocalizedItems();
            handleBGM();
        }
    }
}