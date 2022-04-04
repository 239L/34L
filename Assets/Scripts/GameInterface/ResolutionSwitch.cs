using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NearYouNameSpace.ScriptableObjects;
namespace  NearYouNameSpace.GameInterface{
    public class ResolutionSwitch : MonoBehaviour
    {

        List<string> resolutions;
        Resolution[] rsl;
        public TMP_Dropdown drop;


        [SerializeField] IntValue res;
        public void Awake()
        {

            resolutions = GameResolution.instance.Resolutions;
            drop.ClearOptions();
            drop.AddOptions(resolutions);
            drop.value = res.value;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public void onSwitch(int pos) {
            res.value = pos;

            GameResolution.instance.Resolution();

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}