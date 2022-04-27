using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ObstacleBehaviour : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer sr;

        // Start is called before the first frame update
        void Start()
        {
            //StartCoroutine(changeTexture());
            Texture2D tex = new Texture2D(sr.sprite.texture.width, sr.sprite.texture.height, TextureFormat.ARGB32, false);

            for (int y = 0; y < tex.height; y++)
            {
                for (int x = 0; x < tex.width; x++) //Goes through each pixel
                {
                    Color pixel;
                    pixel = sr.sprite.texture.GetPixel(x, y);

                    tex.SetPixel(x, y, pixel);



                }
            }

            tex.Apply();
            Sprite n_spr = Sprite.Create(tex,
            sr.sprite.textureRect,
            new Vector2(0.5f, 0.5f), sr.sprite.pixelsPerUnit);
            sr.sprite = n_spr;



        }

        IEnumerator changeTexture()
        {

            yield return null;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
