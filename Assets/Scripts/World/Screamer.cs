using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.Controllers;

namespace NearYouNameSpace.World
{
    public class Screamer : MonoBehaviour
    {
        public AnimController anim;
        public CameraController cam;
        float duration = 1f;
        bool finished;
        // Start is called before the first frame update
        void Start()
        {
            finished = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !finished)
            {
                cam.repeatable = true;
                StartCoroutine(Duration());

            }
        }

        IEnumerator Duration()
        {
            anim.setAnim("scream", true);
            yield return new WaitForSeconds(duration);
            anim.setAnim("scream", false);
            finished = true;
            cam.repeatable = false;

        }
    }
}