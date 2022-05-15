using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Player : MonoBehaviour
    {
        private const float DISTANCE = 1.1f;
        private const float RUNCD = 5f;
        Vector3 vector = Vector3.zero;
        [SerializeField]
        FloatValue speed;
        [SerializeField]
        Vector2Value playerPos;
        [SerializeField]
        Rigidbody2D rb;

        [SerializeField]
        StateController playerState;
        [SerializeField]
        Vector2 movement;
        [SerializeField]
        bool dirRight = false;
        [SerializeField]
        AnimController anim;
    float falling_time = 1f;
    public bool cantMove = false;
        
        [SerializeField]
        GameObject runTrack;
        [SerializeField]
        float runCD = RUNCD;
        void Start()
        {

            rb.position = playerPos.pos;
            playerState.changeState(State.idle);

        }

        void Update() {
            checkState();
            movement.x = Input.GetAxisRaw("Horizontal");
            if (((movement.x < 0 && !dirRight) || (movement.x > 0 && dirRight))&&!Pause.isPaused) {
                Flip();
            }
            movement.y = Input.GetAxisRaw("Vertical");
        }
        void FixedUpdate()
        {
            manageState();
            Move();

        }

    public void Freeze() {
        cantMove = true;
    }
    public void Unfreeze() {
        cantMove = false;
    }
        void Flip() {
            dirRight = !dirRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
        
        
        void Move() {
            if(!cantMove)
            rb.MovePosition(rb.position + movement * speed.value * Time.fixedDeltaTime);
        }
        void checkState() {
            if (speed.value == 5f && movement != Vector2.zero) { playerState.changeState(State.run); }
            else if (movement == Vector2.zero)
            {
                playerState.changeState(State.idle);
            }
            else { playerState.changeState(State.move); }

        }

        public  void Fall() {

        StartCoroutine(Falling());
        //SceneController.instance.LoadScene((int)SceneIndexes.GAMEOVER);
        }

    IEnumerator Falling() {
        SoundController.playME(ME.EFFECT2);
        while (falling_time > 0)
        {
           
            falling_time -= Time.deltaTime;
            Vector2 vec = new Vector2(transform.position.x, transform.position.y - 0.1f);
            Quaternion q = transform.rotation;
            q.z -= 0.1f;
            transform.rotation = q;
            transform.position = vec;
            yield return null;
        }
        SceneController.instance.LoadScene((int)SceneIndexes.GAMEOVER);
    }
        
        void manageState() {
            switch (playerState.getState()) {
                case State.move: anim.setAnim("speed", movement.sqrMagnitude); break;
                case State.run: anim.setAnim("speed", speed.value); spawnRunTrack(); break;
                case State.idle: anim.setAnim("speed", 0); break;
                default: break;
            }
        }

        void spawnRunTrack() {
            float dist = Vector2.Distance(vector, transform.position);

            if (dist > DISTANCE || runTrack == null)
            {
                runTrack = Instantiate(Resources.Load("Track"), new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation) as GameObject;
                vector = runTrack.transform.position;
                RunTracks r = runTrack.GetComponent<RunTracks>();
                r.Spawn();
            }
        }

    }

