using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

    public class EnemyController : MonoBehaviour
    {
        public AnimController anim;
        static float durationOfPursuing = 0f;
        // List<Vector2> pathTo = new List<Vector2>();
        public FloatValue EnemySpeed;
        //bool isMoving;
        [SerializeField]
        Vector2Value startPos;
        Transform player;
        
        [SerializeField]
        AIPath ai;
        [SerializeField]
        EnemyState state;
        Vector3 PickRandomPoint()
        {
            var point = Random.insideUnitSphere * ai.radius;
            point.y = 0;
            point += transform.parent.position;
            return point;
        }

        Vector3 PickPointNearPlayer() {
            var point = Random.insideUnitSphere * ai.radius*3;
            point.y = 0;
            point +=player.transform.position/1.2f;
            return point;
        }
        bool collided = false;

        Vector2 dir;
        [SerializeField]
        AIDestinationSetter targetSetter;

        
        
        float pos = 0.0f;
        bool dirRight = true;
        RaycastHit2D hit;

        float tempSpeed = 0f;

        // Start is called before the first frame update
        void Start()
        {
            
            tempSpeed = EnemySpeed.value;
            state.changeState(AIState.idle);
            pos = startPos.pos.y;
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            }
            if (player != null)
            {


            }


        }
       
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collided = true;
            Debug.Log("col");
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            collided = false;
        }
        void Flip()
        {
            dirRight = !dirRight;
            Vector3 Scale = transform.parent.localScale;
            Scale.x *= -1;
            transform.parent.localScale = Scale;
        }
        // Update is called once per frame

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.parent.position, ai.radius);
        }
        void Update()
        {
            if (player == null) return;
            anim.setAnim("EnemySpeed", ai.velocity.sqrMagnitude);
            setState();
            checkState();
            ai.maxSpeed = tempSpeed;
            if ((ai.desiredVelocity.x > 0 && !dirRight) || (ai.desiredVelocity.x < 0 && dirRight))
            {
                Flip();
            }
            dir = ai.desiredVelocity;
            transform.right = dir;


        }

        void setState()
        {
            if (!FindObjectOfType<Player>().cantMove)
            {
                if (ai.isStopped && state.getState() != AIState.onTrack && state.getState() != AIState.pursuing) { SoundController.stopBGS(); state.changeState(AIState.idle); }
                hit = Physics2D.Raycast(transform.parent.position, transform.parent.right, ai.radius);
                if (hit && hit.collider.tag == "runTrack" && state.getState() != AIState.onTrack && state.getState() != AIState.pursuing)
                {

                    SoundController.playBGS(BGS.APPROACH2, true);

                    state.changeState(AIState.onTrack);
                }
                if (FindObjectOfType<RunTracks>() == null && state.getState() == AIState.onTrack)
                {
                    SoundController.stopBGS();
                    state.changeState(AIState.idle);
                }
                if (Vector2.Distance(transform.parent.position, player.position) > ai.radius && state.getState() != AIState.onTrack)
                {
                    SoundController.stopBGS();
                    state.changeState(AIState.outofrange);
                }
                if (Vector2.Distance(transform.parent.position, player.position) <= ai.radius && state.getState() != AIState.pursuing)
                {
                    SoundController.stopBGS();
                    state.changeState(AIState.noticed);
                    //
                }
                if (Vector2.Distance(transform.parent.position, player.position) > ai.radius * 5)
                {
                    SoundController.stopBGS();
                    state.changeState(AIState.lost);


                }

                if (state.getState() == AIState.noticed)
                {
                    state.changeState(AIState.pursuing);

                    SoundController.playBGS(BGS.APPROACH1, true);

                }
            }
            
        }

        void returnSpeed() {
            durationOfPursuing = 0f;
            tempSpeed = EnemySpeed.value;
        }
        void checkState() {
            switch (state.getState()) {
                case AIState.noticed:
                    returnSpeed();
                    targetSetter.enabled = true;
                    

                    break;
                case AIState.lost:
                    returnSpeed();
                    targetSetter.enabled = false;

                    ai.Teleport(PickPointNearPlayer());
                    while (collided)
                    {
                        ai.Teleport(PickPointNearPlayer());
                    }
                    
                    break;
                case AIState.pursuing: targetSetter.enabled = true; if (durationOfPursuing > 3f&&tempSpeed<5f) { tempSpeed += 0.1f; } durationOfPursuing += Time.deltaTime;break;
                case AIState.onTrack:
                    
                    returnSpeed();
                    if (hit)
                    {
                        RunTracks[] tracks = FindObjectsOfType<RunTracks>();

                        if (tracks != null)
                        {
                            targetSetter.enabled = false;
                            ai.destination = tracks[0].transform.position;
                            ai.SearchPath();
                        }
                        
                    }
                    break;
                case AIState.outofrange:
                default:
                    returnSpeed();
                    targetSetter.enabled = false;
                    ai.destination = PickRandomPoint();
                    ai.SearchPath();
                    
                    break;
            }
        }
    }
