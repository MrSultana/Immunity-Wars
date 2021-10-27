using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class TCell : MonoBehaviour {
        private PlayerEnemy tCell;

        public GameObject healthBar;
        public GameObject actionBar;

        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            tCell = gameObject.AddComponent<PlayerEnemy>();
            tCell.defaultPlayerActionPoints = 3;
            tCell.playerActionPoints = tCell.defaultPlayerActionPoints;
            tCell.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
            foreach (var x in PlayerEnemy.startingPositions) {
                Debug.Log(x.ToString());
            }
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "TCell") {
                healthBar.GetComponent<Slider>().value = tCell.playerHealth;
                actionBar.GetComponent<Slider>().value = tCell.playerActionPoints;
                tCell.MovePlayer();
            }

            if (tCell.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                tCell.PointsRefresh(tCell.playerActionPoints, tCell.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) && tCell.canMove) {
                //Debug.Log(TurnManager.currentTurn);
                tCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                tCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}