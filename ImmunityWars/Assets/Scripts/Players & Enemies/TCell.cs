using UnityEngine;

namespace Interaction {

    public class TCell : MonoBehaviour {
        private Player tCell = new Player(3, 3);
        //public TurnManager manageTurn = new TurnManager();

        // Start is called before the first frame update
        private void Start() { 
        }

        // Update is called once per frame
        private void Update() {
            if (tCell.manageTurn.currentTurn == tCell.manageTurn.turns[0]) {
                tCell.MovePlayer();
                if (Input.GetMouseButton(0)) {
                    tCell.playerActionPoints -= 1;
                }
            }
            
        }
    }
}