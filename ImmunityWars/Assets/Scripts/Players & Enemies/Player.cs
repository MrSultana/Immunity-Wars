using UnityEngine;

namespace Interaction {

    public class Player : MonoBehaviour {
        private int playerHealth;
        private int defaultPlayerActionPoints;
        private int playerActionPoints;
        private bool newTurn = false;
        private Vector3 newPosition;
        //PathFind.Grid grid;
        //Vector3 clickPosition;

        public Player(int playerHealth, int defaultPlayerActionPoints) {
            this.playerHealth = playerHealth;
            this.playerActionPoints = defaultPlayerActionPoints;
        }

        private void Start() {
            newPosition = transform.position;
        }

        private void Update() {
        }

        public void MovePlayer() {
            if (Input.GetMouseButton(0)) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log(hit.point);
                    newPosition = hit.point;
                    newPosition.y = 1.2f;
                    newPosition = ExtensionMethods.RoundVector3(newPosition, 1.2f);
                    transform.position = newPosition;
                }
            }
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

        public void FindClickPosition() {
        }
    }
}