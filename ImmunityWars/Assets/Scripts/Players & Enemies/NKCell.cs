using UnityEngine;

namespace Interaction {

    public class NKCell : MonoBehaviour {
        private Player nkCell;
        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            nkCell = gameObject.AddComponent<Player>();
            nkCell.defaultPlayerActionPoints = 3;
            nkCell.playerActionPoints = nkCell.defaultPlayerActionPoints;
            nkCell.playerHealth = 2;
        }


        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "NKCell") {
                nkCell.MovePlayer();
            }

            if (nkCell.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                nkCell.PointsRefresh(nkCell.playerActionPoints, nkCell.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) && nkCell.withinDistance) {
                Debug.Log(TurnManager.currentTurn);
                nkCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                nkCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}
