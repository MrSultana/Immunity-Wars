using UnityEngine;

namespace Interaction {

    public class TCell : MonoBehaviour {
        private Player tCell;
        public TurnManager manageTurn = new TurnManager();

        // Start is called before the first frame update
        private void Start() {
            tCell = gameObject.AddComponent<Player>();
        }

        // Update is called once per frame
        private void Update() {
            if (TurnManager)
            tCell.MovePlayer();
        }
    }
}