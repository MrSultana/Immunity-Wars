using UnityEngine;
using System;
using Pathfinding;

namespace interaction {
    public class EnemyAIMovement : MonoBehaviour {
        public Transform targetPlayer;
        public GameObject[] players;
        public Vector3[] playersDistance;

        public EnemyAIMovement() {

        }
        // Start is called before the first frame update
        private void Start() {
            Seeker seeker = GetComponent<Seeker>();
            MoveToPlayer();
           
            //seeker.StartPath(transform.position, targetPlayer.position, OnPathComplete);
            //will implement when proper player recognition is working
        }

        public void MoveToPlayer() {
            players = GameObject.FindGameObjectsWithTag("Player");

            /*foreach (GameObject player in players) {
                Debug.Log(player.name);
            }*/
        }
        public void OnPathComplete(Path p) {
            Debug.Log("Path returned. Did it have an error?" + p.error);
        }
    }
}