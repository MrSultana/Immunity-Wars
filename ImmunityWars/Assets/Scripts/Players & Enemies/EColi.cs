using UnityEngine;

namespace Interaction {

    public class EColi : MonoBehaviour {
        private PlayerEnemy eColi;
        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            eColi = gameObject.AddComponent<PlayerEnemy>();
            eColi.defaultPlayerActionPoints = 3;
            eColi.playerActionPoints = eColi.defaultPlayerActionPoints;
            eColi.playerHealth = 3;
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "EColi") {
                eColi.MovePlayer();
            }

            if (eColi.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                eColi.PointsRefresh(eColi.playerActionPoints, eColi.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) /*&& eColi.withinDistance*/) {
                Debug.Log(TurnManager.currentTurn);
                eColi.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                eColi.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}