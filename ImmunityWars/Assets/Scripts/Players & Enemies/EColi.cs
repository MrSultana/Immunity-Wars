using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class EColi : MonoBehaviour {
        private PlayerEnemy eColi;

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
            eColi = gameObject.AddComponent<PlayerEnemy>();
            eColi.indicatorsText = indicatorsText;
            eColi.defaultPlayerActionPoints = 3;
            eColi.playerActionPoints = eColi.defaultPlayerActionPoints;
            eColi.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "EColi") {
                healthBar.GetComponent<Slider>().value = eColi.playerHealth;
                actionBar.GetComponent<Slider>().value = eColi.playerActionPoints;
                halo.enabled = true;
                eColi.MovePlayer();
            } else {
                halo.enabled = false;
            }

            if (eColi.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                eColi.PointsRefresh(eColi.playerActionPoints, eColi.defaultPlayerActionPoints);
            }

            if (eColi.playerHealth == 0) {
                deathSoundPlayer.Play();
                // Changes indicator text on HUD
                gameManagement.GetComponent<GameManagement>().StartIndicator("E. coli has been eliminated");
            }

            if (Input.GetMouseButtonDown(0) && eColi.canMove) {
                movementSoundPlayer.Play();
                gameManagement.GetComponent<GameManagement>().StartIndicator("E. coli has moved");
                eColi.playerActionPoints -= 1;
            } else if (Input.GetMouseButtonDown(0) && eColi.canAttack) {
                attackSoundPlayer.Play();
                eColi.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                eColi.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}