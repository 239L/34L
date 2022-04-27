using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 public class AudioSwitch : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        FloatValue value;

        [SerializeField]
        Slider slider;


        public void onSwitch(float val)
        {
            value.value = val;
            SoundAssets.Instance.setVolume();
        }
        void Start()
        {
            slider.value = value.value;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
