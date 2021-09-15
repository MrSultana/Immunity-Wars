using UnityEngine;

namespace Interaction {

    public class Covid19 : MonoBehaviour {
        private Player covid19;
        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            covid19 = gameObject.AddComponent<Player>();
            covid19.defaultPlayerActionPoints = 3;
            covid19.playerActionPoints = covid19.defaultPlayerActionPoints;
            covid19.playerHealth = 3;
        }


        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "Covid19") {
                covid19.MovePlayer();
            }

            if (covid19.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                covid19.PointsRefresh(covid19.playerActionPoints, covid19.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0)) {
                Debug.Log(TurnManager.currentTurn);
                covid19.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                covid19.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}
