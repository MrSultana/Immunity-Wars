using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class Neutrophil : MonoBehaviour {
        private PlayerEnemy neutrophil;

        public GameObject healthBar;
        public GameObject actionBar;

        public Behaviour halo;

        public Text indicatorsText;

        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            neutrophil = gameObject.AddComponent<PlayerEnemy>();
            neutrophil.indicatorsText = indicatorsText;
            neutrophil.defaultPlayerActionPoints = 3;
            neutrophil.playerActionPoints = neutrophil.defaultPlayerActionPoints;
            neutrophil.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "Neutrophil") {
                healthBar.GetComponent<Slider>().value = neutrophil.playerHealth;
                actionBar.GetComponent<Slider>().value = neutrophil.playerActionPoints;
                halo.enabled = true;
                neutrophil.MovePlayer();
            } else {
                halo.enabled = false;
            }

            if (neutrophil.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                neutrophil.PointsRefresh(neutrophil.playerActionPoints, neutrophil.defaultPlayerActionPoints);
            }

            if (Input.GetMouseButtonDown(0) && neutrophil.canMove) {
                Debug.Log(TurnManager.currentTurn);
                neutrophil.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                neutrophil.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}