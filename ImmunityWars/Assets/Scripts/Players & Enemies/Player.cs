using UnityEngine;

namespace Interaction {

    public class Player : MonoBehaviour {
        public int playerHealth;
        private int defaultPlayerActionPoints;
        public int playerActionPoints;

        //public TurnManager manageTurn;
        private Vector3 newPosition;

        public int testValue = 3;
        //PathFind.Grid grid;
        //Vector3 clickPosition;

        public Player(int playerHealth, int defaultPlayerActionPoints) {
            this.playerHealth = playerHealth;
            playerActionPoints = defaultPlayerActionPoints;
            //manageTurn = gameObject.AddComponent<TurnManager>();
        }

        private void Start() {
            newPosition = transform.position;
        }

        private void Update() {
            //TurnChange();
            //manageTurn.TurnEnd();
        }

        public void TurnChange() {
            if (playerActionPoints == 0) {
                //manageTurn.turnEnd = true;
                playerActionPoints = defaultPlayerActionPoints;
            }
        }

        public void MovePlayer() {
            if (Input.GetMouseButton(0)) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    //Debug.Log(hit.point);
                    newPosition = hit.point;
                    newPosition.y = 1.2f;
                    newPosition = ExtensionMethods.RoundVector3(newPosition, 1.2f);
                    Debug.Log(newPosition);
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

        /*private void PointsRefresh(int playerActionPoints) {
            if (newTurn) {
                playerActionPoints = defaultPlayerActionPoints;
            }
        }*/

        public void FindClickPosition() {
        }
    }
}