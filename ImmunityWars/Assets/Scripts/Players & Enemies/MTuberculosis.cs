using UnityEngine;

namespace Interaction {

    public class MTuberculosis : MonoBehaviour {
        private PlayerEnemy mTuberculosis;
        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            mTuberculosis = gameObject.AddComponent<PlayerEnemy>();
            mTuberculosis.defaultPlayerActionPoints = 3;
            mTuberculosis.playerActionPoints = mTuberculosis.defaultPlayerActionPoints;
            mTuberculosis.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "MTuberculosis") {
                mTuberculosis.MovePlayer();
            }

            if (mTuberculosis.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                mTuberculosis.PointsRefresh(mTuberculosis.playerActionPoints, mTuberculosis.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) && mTuberculosis.canMove) {
                Debug.Log(TurnManager.currentTurn);
                mTuberculosis.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                mTuberculosis.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}