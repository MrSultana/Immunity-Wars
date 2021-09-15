using UnityEngine;

namespace Interaction {

    public class KillerTCell : MonoBehaviour {
        private Player killerTCell;
        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            killerTCell = gameObject.AddComponent<Player>();
            killerTCell.defaultPlayerActionPoints = 3;
            killerTCell.playerActionPoints = killerTCell.defaultPlayerActionPoints;
            killerTCell.playerHealth = 3;
        }


        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "KillerTCell") {
                killerTCell.MovePlayer();
            }

            if (killerTCell.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                killerTCell.PointsRefresh(killerTCell.playerActionPoints, killerTCell.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0)) {
                Debug.Log(TurnManager.currentTurn);
                killerTCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                killerTCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}
