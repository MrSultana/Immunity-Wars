using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class KillerTCell : MonoBehaviour {
        private PlayerEnemy killerTCell;

        public GameObject healthBar;
        public GameObject actionBar;

        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            killerTCell = gameObject.AddComponent<PlayerEnemy>();
            killerTCell.defaultPlayerActionPoints = 3;
            killerTCell.playerActionPoints = killerTCell.defaultPlayerActionPoints;
            killerTCell.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "KillerTCell") {
                healthBar.GetComponent<Slider>().value = killerTCell.playerHealth;
                actionBar.GetComponent<Slider>().value = killerTCell.playerActionPoints;
                killerTCell.MovePlayer();
            }

            if (killerTCell.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                killerTCell.PointsRefresh(killerTCell.playerActionPoints, killerTCell.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) && killerTCell.canMove) {
                Debug.Log(TurnManager.currentTurn);
                killerTCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                killerTCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}