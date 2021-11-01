using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class NKCell : MonoBehaviour {
        private PlayerEnemy nkCell;

        public GameObject healthBar;
        public GameObject actionBar;

        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            nkCell = gameObject.AddComponent<PlayerEnemy>();
            nkCell.defaultPlayerActionPoints = 3;
            nkCell.playerActionPoints = nkCell.defaultPlayerActionPoints;
            nkCell.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "NKCell") {
                healthBar.GetComponent<Slider>().value = nkCell.playerHealth;
                actionBar.GetComponent<Slider>().value = nkCell.playerActionPoints;
                nkCell.MovePlayer();
            }

            if (nkCell.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                nkCell.PointsRefresh(nkCell.playerActionPoints, nkCell.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) && nkCell.canMove) {
                Debug.Log(TurnManager.currentTurn);
                nkCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                nkCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}