using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayButton : CustomButton
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        override public void onClick()
        {

            base.onClick();
            setScene();
        }
        override public void setScene()
        {
            SceneController.instance.LoadScene((int)SceneIndexes.GAME);
        }
    }
