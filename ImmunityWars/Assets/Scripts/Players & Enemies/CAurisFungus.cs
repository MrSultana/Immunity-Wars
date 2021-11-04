using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class CAurisFungus : MonoBehaviour {
        private PlayerEnemy cAuris;

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
            cAuris = gameObject.AddComponent<PlayerEnemy>();
            cAuris.indicatorsText = indicatorsText;
            cAuris.defaultPlayerActionPoints = 3;
            cAuris.playerActionPoints = cAuris.defaultPlayerActionPoints;
            cAuris.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "CAurisFungus") {
                healthBar.GetComponent<Slider>().value = cAuris.playerHealth;
                actionBar.GetComponent<Slider>().value = cAuris.playerActionPoints;
                halo.enabled = true;
                cAuris.MovePlayer();
            } else {
                halo.enabled = false;
            }

            if (cAuris.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                cAuris.PointsRefresh(cAuris.playerActionPoints, cAuris.defaultPlayerActionPoints);
            }

            if (cAuris.playerHealth == 0) {
                deathSoundPlayer.Play();
                // Changes indicator text on HUD
                gameManagement.GetComponent<GameManagement>().StartIndicator("C. auris has been eliminated");
            }

            if (Input.GetMouseButtonDown(0) && cAuris.canMove) {
                movementSoundPlayer.Play();
                gameManagement.GetComponent<GameManagement>().StartIndicator("C. auris has moved");
                cAuris.playerActionPoints -= 1;
            } else if (Input.GetMouseButtonDown(0) && cAuris.canAttack) {
                attackSoundPlayer.Play();
                cAuris.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                cAuris.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}