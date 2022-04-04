using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NearYouNameSpace.Coroutines
{
    public enum Type
    {
        Sprite,
        CanvasGr
    }
    public class Fader : MonoBehaviour
    {
        [SerializeField] SpriteRenderer sr;
        CanvasGroup cg;

        public SpriteRenderer Sr
        {
            get { return sr; }
            set { sr = value; }
        }
        private bool isFaded = false;
        private bool unFaded = false;
        private bool Waited = false;

        public bool IsFaded
        {
            get { return isFaded; }
            set { isFaded = value; }
        }
        public bool UnFaded
        {
            get { return unFaded; }
            set { unFaded = value; }
        }


        public void FadeIn(bool wait = false, float s = 0f)
        {
            if (wait) { StartCoroutine(WaitBefore(s, this.sr.material.color.a, 1f)); }
            { StartCoroutine(Fade(this.sr.material.color.a, 1f)); }

        }

        public void FadeOut(bool wait = false, float s = 0f)
        {
            if (wait) { StartCoroutine(WaitBefore(s, this.sr.material.color.a, 0f)); } else { StartCoroutine(Fade(this.sr.material.color.a, 0f)); }
        }

        public void FadeIn(CanvasGroup cg, bool wait = false, float s = 0f)
        {
            this.cg = cg;
            if (wait) { StartCoroutine(WaitBefore(s, this.cg.alpha, 1)); } else { StartCoroutine(Fade(this.cg.alpha, 1)); }
        }

        public void FadeOut(CanvasGroup cg, bool wait = false, float s = 0f)
        {
            this.cg = cg;
            if (wait) { StartCoroutine(WaitBefore(s, this.cg.alpha, 0)); } else { StartCoroutine(Fade(this.cg.alpha, 0)); }
        }
        /*IEnumerator WaitBefore(float value, float alpha) {
            yield return new WaitForSeconds(value);
            Waited = true;
            StartCoroutine(Fade(alpha));
        }*/
        IEnumerator WaitBefore(float value, float start, float end, float lerp = 0.5f)
        {
            yield return new WaitForSeconds(value);
            Waited = true;
            StartCoroutine(Fade(start, end, lerp));
        }


        IEnumerator Fade(float start, float end, float lerp = 0.5f)
        {
            float timeStartedLerp = Time.time;
            float timeSinceStarted = Time.time - timeStartedLerp;
            float complete = timeSinceStarted / lerp;
            while (true)
            {
                timeSinceStarted = Time.time - timeStartedLerp;
                complete = timeSinceStarted / lerp;
                float current = Mathf.Lerp(start, end, complete);
                if (cg)
                {
                    cg.alpha = current;
                }
                else
                {
                    Color c = new Color();
                    c.a = current;
                    sr.material.color = c;
                }

                if (complete >= 1) { if (current == 1f) { isFaded = false; unFaded = true; } else { isFaded = true; unFaded = false; } break; }
                yield return new WaitForFixedUpdate();
            }
        }

        /*IEnumerator Fade(float alpha)
         {
             switch (alpha) {
                 case 0:
                     for (float ft = 1f; ft > 0.0f; ft -= 0.1f)
                     {
                         Color c = sr.material.color;
                         c.a = ft;
                         sr.material.color = c;
                         Debug.Log(c.a);
                         if (c.a <= 0.1f) { isFaded = true; }
                         yield return null;
                     }break;
                 case 1:
                 default:
                     for (float ft = 0f; ft < 1.0f; ft += 0.1f)
                     {
                         Color c = sr.material.color;
                         c.a = ft;
                         sr.material.color = c;
                         Debug.Log(c.a);
                         if (c.a >= 1.0f) { isFaded = true; }
                         yield return null;
                     } break;
             }

         }*/
    }
}