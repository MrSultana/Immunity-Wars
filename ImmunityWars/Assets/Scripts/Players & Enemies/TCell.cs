using UnityEngine;

namespace Interaction {

    public class TCell : MonoBehaviour {
        private Player tCell;
        public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            tCell = gameObject.AddComponent<Player>();
        }

        // Update is called once per frame
        private void Update() {
            tCell.MovePlayer();

            /*if (Input.GetMouseButton(0)) {
                tCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}