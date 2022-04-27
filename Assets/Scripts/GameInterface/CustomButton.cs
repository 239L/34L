using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

    public abstract class CustomButton : MonoBehaviour
    {
        int index;
        public TextMeshProUGUI text;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual void onClick()
        {
            SoundController.playSE(SE.CLICK);
        }
        public virtual void onHover() { }

        public virtual void onHoverExit() { }

        public virtual void setScene()
        {
            SceneController.instance.LoadScene(index);
        }
    }
