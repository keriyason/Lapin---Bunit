using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
        public float speed = 0.5f; //speed of platforms
        public Transform pointA;
        public Transform pointB;

        [Header("Platform Settings")]
        public float waitTime = 2.5f; // how long the platform will wait before moving from pointA to pointB


        private Vector3 target;
        private bool isWaiting = false; //checks if the platform has reached a point

        void Start()
        {
            target = pointB.position; // starts moving toward point b
        }

        void Update()
        {
            if (!isWaiting) //checks if the platform is not waiting
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target) < 0.1f)
                {
                    StartCoroutine(WaitAndSwitch()); //starts cycle of point a to point b w delay
                }
            }
        }

        private System.Collections.IEnumerator WaitAndSwitch()
        {
            isWaiting = true; //platform is waiting to move to next point


            yield return new WaitForSeconds(waitTime); // waits for platform waittime 


            target = (target == pointA.position) ? pointB.position : pointA.position; // point b -> point a

            isWaiting = false;
        }

        private void OnCollisionEnter2D(Collision other) // attachs the player to the platform = no fall
        {
            if (other.collider.CompareTag("Player"))
            {
                other.collider.transform.SetParent(transform);
            }
        }
        private void OnCollisionExit(Collision collision) // once player exits platform remove the player as parent
        {
            if (collision.collider.CompareTag("Player"))
            {
                collision.collider.transform.SetParent(null);
            }
        }
    }

