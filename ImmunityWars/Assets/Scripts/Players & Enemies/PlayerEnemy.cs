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

        public static List<Vector3> currentPositions = new List<Vector3>();
        public static List<Vector3> startingPositions = new List<Vector3>();

        public bool canMove = false;

        private GameObject colliderGameobject;

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
            //healthBar.fillAmount = playerHealth / MaxHealth;
            Death();
        }

        public void MovePlayer() {
            canMove = false;
            if (Input.GetMouseButtonDown(0)) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Creates a new ray that is released from the camera to the the mouse click position
                if (Physics.Raycast(ray, out RaycastHit hit)) { // Checks if the raycast hits a collider on the layer "Raycollision"
                    colliderGameobject = hit.collider.gameObject;

                    if (colliderGameobject.GetComponent("Capsule Collider") && colliderGameobject.CompareTag("Player") || colliderGameobject.CompareTag("Enemy")) { // If the user clicked on a player or enemy
                        Debug.Log("Jeff");
                        if (colliderGameobject == gameObject) {
                            Debug.Log("Won't damage myself!");
                            return; // Cancel attack if user clicked on the current player or enemy
                        }
                        else if (colliderGameobject.CompareTag(gameObject.tag)) {
                            Debug.Log("Can't attack my own team!");
                            return; // Cancel attack if the user tried to attack a character of the same team
                        }
                        else {
                            GameObject objectHit = colliderGameobject;
                            if (ExtensionMethods.AccountingForPlayerEnemyDistance(transform.position, colliderGameobject.transform.position)) {
                                Attack(objectHit); // Run the attack method on the clicked player or enemy
                                canMove = true;
                            } else {
                                Debug.Log("Too far!");
                            }  
                        }
                    }
                     
                    // If the click point hits anywhere on the grid that isn't a player or enemy
                    if (colliderGameobject.tag != "Player" && colliderGameobject.tag != "Enemy") {
                        newPosition = hit.point;
                        newPosition.y = 1.2f;
                        newPosition = ExtensionMethods.RoundVector3(newPosition, 1.2f);
                        withinDistance = ExtensionMethods.FindDifferenceBetweenVector3(transform.position, newPosition);
                        if (withinDistance) {
                            transform.position = newPosition;
                            canMove = true;
                        }
                    }

                    //Adds the final player position to the currentPositions array for position tracking
                    if (playerActionPoints == 0) {
                        AddPositionToArray(transform.position);
                        foreach (var x in currentPositions) {
                            Debug.Log(x.ToString());
                        }
                    }
                }
            }
        }

        public void AddPositionToArray(Vector3 position) {
            currentPositions.Add(position);
        }

        private void Damage(GameObject victimDamage) {
            if (victimDamage.GetComponent<PlayerEnemy>()) {
                victimDamage.GetComponent<PlayerEnemy>().playerHealth -= 1;
            }
        }

        private void Death() {
            if (playerHealth == 0) {
                gameObject.SetActive(false);
                Debug.Log("Victim destroyed");
            }
        }

        public void Attack(GameObject victimAttack) {
            Damage(victimAttack);
            Debug.Log("Victim attacked");
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