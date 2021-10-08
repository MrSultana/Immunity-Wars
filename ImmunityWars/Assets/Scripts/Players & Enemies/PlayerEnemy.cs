using System.Collections.Generic;
using UnityEngine;

namespace Interaction {

    public class PlayerEnemy : MonoBehaviour {
        public int playerHealth;
        public int defaultPlayerActionPoints;
        public int playerActionPoints;
        private Vector3 newPosition;
        public TurnManager manageTurn;
        public int testValue = 3;
        public bool withinDistance;
        public static List<Vector3> currentPositions;
        //PathFind.Grid grid;
        //Vector3 clickPosition;

        public PlayerEnemy(int playerHealth, int defaultPlayerActionPoints) {
            this.playerHealth = playerHealth;
            playerActionPoints = defaultPlayerActionPoints;
            manageTurn = GameObject.Find("TurnManager").GetComponent<TurnManager>();
            //manageTurn = gameObject.AddComponent<TurnManager>();
        }

        private void Start() {
        }

        private void Update() {
        }

        public void MovePlayer() {
            if (Input.GetMouseButton(0)) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit)) {
                    //Debug.Log(hit.point);
                    newPosition = hit.point;
                    newPosition.y = 1.2f;
                    newPosition = ExtensionMethods.RoundVector3(newPosition, 1.2f);
                    withinDistance = ExtensionMethods.FindDifferenceBetweenVector3(transform.position, newPosition);
                    //if (!currentPositions.Contains(newPosition)) {
                    transform.position = newPosition;
                    //AddPositionToArray(transform.position);
                    //}
                    //if (withinDistance) {
                    //Debug.Log(newPosition);

                    //}
                }
            }
        }

        public void AddPositionToArray(Vector3 position) {
            currentPositions.Add(position);
        }

        private void Damage(int damage) {
            playerHealth = playerHealth - damage;
        }

        private void Action(int pointsUsed) {
            playerActionPoints = playerActionPoints - pointsUsed;
        }

        public void PointsRefresh(int actionPoints, int defaultActionPoints) {
            if (TurnManager.newTurn) {
                playerActionPoints = defaultPlayerActionPoints;
            }
        }
    }
}