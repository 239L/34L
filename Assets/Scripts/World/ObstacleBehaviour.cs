using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


    public class ObstacleBehaviour : MonoBehaviour, IAnimator
    {
    [SerializeField] AnimController anim;
    public void playAnimation()
    {

        anim.setAnim("Erase",true);
        Invoke("Disable", 1f);
    }

    void Disable() {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
