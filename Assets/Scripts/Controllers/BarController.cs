using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NearYouNameSpace.Coroutines;
namespace NearYouNameSpace.Controllers
{
    public class BarController : MonoBehaviour
    {
        [SerializeField]
        Slider slider;
        [SerializeField]
        Fader fader;
        [SerializeField]
        CanvasGroup cg;
        private bool isShown = false;
        private float min, max;

        public bool getFinished()
        {
            return fader.UnFaded;
        }
        private void Start()
        {
            cg = slider.GetComponent<CanvasGroup>();
        }
        public void setMinMax(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
        public void Activate(float value, bool io)
        {

            if (io)
            { fader.FadeIn(cg); }
            else { fader.FadeOut(cg); }
            slider.value = value;


        }

    }
}