using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class SAureus : MonoBehaviour {
        private PlayerEnemy sAureus;

        public GameObject healthBar;
        public GameObject actionBar;

        public Behaviour halo;

        public Text indicatorsText;
        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            sAureus = gameObject.AddComponent<PlayerEnemy>();
            sAureus.indicatorsText = indicatorsText;
            sAureus.defaultPlayerActionPoints = 3;
            sAureus.playerActionPoints = sAureus.defaultPlayerActionPoints;
            sAureus.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "SAureus") {
                healthBar.GetComponent<Slider>().value = sAureus.playerHealth;
                actionBar.GetComponent<Slider>().value = sAureus.playerActionPoints;
                halo.enabled = true;
                sAureus.MovePlayer();
            } else {
                halo.enabled = false;
            }

            if (sAureus.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                sAureus.PointsRefresh(sAureus.playerActionPoints, sAureus.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) && sAureus.canMove) {
                Debug.Log(TurnManager.currentTurn);
                sAureus.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                sAureus.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}