using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    public class Player : MonoBehaviour {
        int playerHealth;
        int defaultPlayerActionPoints;
        int playerActionPoints;
        bool newTurn = false;
        //PathFind.Grid grid;
        Vector3 clickPosition;

        public Player(int playerHealth, int defaultPlayerActionPoints) {
            this.playerHealth = playerHealth;
            this.playerActionPoints = defaultPlayerActionPoints;
        }
        private void Damage(int damage) {
            playerHealth = playerHealth - damage;
        }

        private void Action(int pointsUsed) {
            playerActionPoints = playerActionPoints - pointsUsed;
        }

        private void PointsRefresh(int playerActionPoints) {
            if (newTurn) {
                playerActionPoints = defaultPlayerActionPoints;
            }
        }

        public void MovePlayer() {
            //grid = GridMaker.ReturnGrid();

        }

        public Vector3 FindClickPosition() {
            // Cast a ray from screen point
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Save the info
            RaycastHit hit;
            // You successfully hi
            if (Physics.Raycast(ray, out hit)) {
                // Find the direction to move in
                Vector3 dir = hit.point - transform.position;

                // Make it so that its only in x and y axis
                dir.y = 0; // No vertical movement

                transform.Translate(dir);


                // Now move your character in world space 
                // transform.Translate(dir * Time.deltaTime * speed, Space.World);

                // transform.Translate (dir * Time.DeltaTime * speed); // Try this if it doesn't work
            }

            return clickPosition;
        }
    }
}

