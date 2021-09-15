using UnityEngine;

namespace Interaction {

    public class TCell : MonoBehaviour {
        private Player tCell;
        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            tCell = gameObject.AddComponent<Player>();
            tCell.defaultPlayerActionPoints = 3;
            tCell.playerActionPoints = tCell.defaultPlayerActionPoints;
            tCell.playerHealth = 3;
        }


        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "TCell") {
                tCell.MovePlayer();
            }

            if (tCell.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                tCell.PointsRefresh(tCell.playerActionPoints, tCell.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0)) {
                Debug.Log(TurnManager.currentTurn);
                tCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                tCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}