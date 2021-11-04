using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class Neutrophil : MonoBehaviour {
        private PlayerEnemy neutrophil;

        public GameObject healthBar;
        public GameObject actionBar;

        public Behaviour halo;

        public Text indicatorsText;

        public GameObject gameManagement;

        // For sound effects
        public AudioSource deathSoundPlayer;
        public AudioSource movementSoundPlayer;
        public AudioSource attackSoundPlayer;

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

            if (neutrophil.playerHealth == 0) {
                deathSoundPlayer.Play();
                // Changes indicator text on HUD
                gameManagement.GetComponent<GameManagement>().StartIndicator("Neutrophil has been eliminated");
            }

            if (Input.GetMouseButtonDown(0) && neutrophil.canMove) {
                movementSoundPlayer.Play();
                gameManagement.GetComponent<GameManagement>().StartIndicator("Neutrophil has moved");
                neutrophil.playerActionPoints -= 1;
            } else if (Input.GetMouseButtonDown(0) && neutrophil.canAttack) {
                attackSoundPlayer.Play();
                neutrophil.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                neutrophil.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}