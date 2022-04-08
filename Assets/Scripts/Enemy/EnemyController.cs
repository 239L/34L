using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using NearYouNameSpace.Controllers;
using NearYouNameSpace.ScriptableObjects;

namespace NearYouNameSpace.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public AnimController anim;

        // List<Vector2> pathTo = new List<Vector2>();
        public FloatValue EnemySpeed;
        //bool isMoving;
        [SerializeField]
        Vector2Value startPos;
        Transform player;
        
        [SerializeField]
        AIPath ai;

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

        // Start is called before the first frame update
        void Start()
        {

            pos = startPos.pos.y;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            anim.setAnim("EnemySpeed", ai.velocity.sqrMagnitude);
            if (player == null) return;
            if (Vector2.Distance(transform.parent.position, player.position) <= ai.radius)
            {

                targetSetter.enabled = true;
            }
            if (Vector2.Distance(transform.parent.position, player.position) > ai.radius * 5)
            {
                targetSetter.enabled = false;
                
                ai.Teleport(PickPointNearPlayer());
                while (collided) {
                    ai.Teleport(PickPointNearPlayer());
                }
                
            }
            else if (Vector2.Distance(transform.parent.position, player.position) > ai.radius)
            {
                
              //hit = Physics2D.Raycast(transform.parent.position, transform.parent.right, ai.radius);
              targetSetter.enabled = false;
             ai.destination = PickRandomPoint();
              ai.SearchPath();
 
            }
            




                if ((ai.desiredVelocity.x > 0 && !dirRight) || (ai.desiredVelocity.x < 0 && dirRight))
            {
                Flip();
            }
            dir = ai.desiredVelocity;
            transform.right = dir;


        }
    }
}