using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NearYouNameSpace.ScriptableObjects;

namespace NearYouNameSpace.GameInterface
{
    public class GameResolution : MonoBehaviour
    {
        public static GameResolution instance;

        List<string> resolutions;
        Resolution[] rsl;
        [SerializeField] BoolValue windowed;
        public List<string> Resolutions
        {
            get { return resolutions; }
        }
        // Start is called before the first frame update
        void Start()
        {


        }

        [SerializeField] IntValue res;
        public void Resolution()
        {

            Screen.SetResolution(Screen.resolutions[res.value].width, Screen.resolutions[res.value].height, Screen.fullScreen);
        }
        // Update is called once per frame

        public void setFullScreen()
        {
            Screen.fullScreen = !Screen.fullScreen;

        }
        private void Awake()
        {
            if (instance == null)
            { instance = this; }
            else Destroy(gameObject);
            resolutions = new List<string>();

            rsl = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
            //Debug.Log(rsl.Length);
            for (int i = 0; i < rsl.Length; i++)
            {

                resolutions.Add(rsl[i].width + "x" + rsl[i].height);
                //Debug.Log(resolutions[i]);
                if (rsl[i].width == Screen.currentResolution.width && rsl[i].height == Screen.currentResolution.height && res.value == -1)
                {
                    res.value = i;
                }

            }
            setFullScreen();
            Resolution();

            DontDestroyOnLoad(this);
        }
        void Update()
        {

        }
    }
}