using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class RunTracks : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] Fader fader;
        [SerializeField] SpriteRenderer sr;
        [SerializeField] BoxCollider2D col;

        public void Spawn()
        {

            fader.FadeOut(true, 3f);
        }


        private void Update()
        {
            if (fader.IsFaded) Destroy(this.gameObject);
        }


    }
