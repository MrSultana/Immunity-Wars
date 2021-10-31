using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class BCell : MonoBehaviour {
        private PlayerEnemy bCell;

        public GameObject healthBar;
        public GameObject actionBar;

        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            bCell = gameObject.AddComponent<PlayerEnemy>();
            bCell.defaultPlayerActionPoints = 3;
            bCell.playerActionPoints = bCell.defaultPlayerActionPoints;
            bCell.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "BCell") {
                healthBar.GetComponent<Slider>().value = bCell.playerHealth;
                actionBar.GetComponent<Slider>().value = bCell.playerActionPoints;
                bCell.MovePlayer();
            }

            if (bCell.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                bCell.PointsRefresh(bCell.playerActionPoints, bCell.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) && bCell.canMove) {
                Debug.Log(TurnManager.currentTurn);
                bCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                bCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}