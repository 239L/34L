using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Wire : MonoBehaviour, IAnimator
    {
        [SerializeField]
        AnimController anim;

        [SerializeField]
        private int position;
        private void Awake()
        {

        }
        private void Start()
        {
            for (int i = 0; i < this.transform.parent.childCount; i++)
            {
                if (transform == transform.parent.GetChild(i)) { position = i; }
            }
        }
        public void playAnimation()
        {
            if (EventsController.instance.CurrentInteractable.transform == this.transform.parent)
            {
                if (this.position == 0)
                {


                    if (this.gameObject.transform.localRotation.eulerAngles.z == 90)
                    {

                        changeRotation();

                    }
                    anim.setAnim("Cut", true);
                }
                if (this.position == this.transform.parent.childCount - 1)
                {
                    if (this.gameObject.transform.localRotation.eulerAngles.z == 0)
                    {
                        Debug.Log("f");
                        changeRotation();
                    }
                    anim.setAnim("CutRight", true);
                }
            }

        }

        void changeRotation()
        {
            Quaternion q = this.transform.rotation;
            q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, q.eulerAngles.z + 180);
            this.gameObject.transform.rotation = q;
        }
    }
