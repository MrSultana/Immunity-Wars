using UnityEngine;

namespace Interaction {

    public class Neutrophil : MonoBehaviour {
        private Player neutrophil;
        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            neutrophil = gameObject.AddComponent<Player>();
            neutrophil.defaultPlayerActionPoints = 3;
            neutrophil.playerActionPoints = neutrophil.defaultPlayerActionPoints;
            neutrophil.playerHealth = 3;
        }


        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "Neutrophil") {
                neutrophil.MovePlayer();
            }

            if (neutrophil.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                neutrophil.PointsRefresh(neutrophil.playerActionPoints, neutrophil.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0)) {
                Debug.Log(TurnManager.currentTurn);
                neutrophil.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                neutrophil.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}