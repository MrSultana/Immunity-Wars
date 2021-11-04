using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class NKCell : MonoBehaviour {
        private PlayerEnemy nkCell;

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
            nkCell = gameObject.AddComponent<PlayerEnemy>();
            nkCell.indicatorsText = indicatorsText;
            nkCell.defaultPlayerActionPoints = 3;
            nkCell.playerActionPoints = nkCell.defaultPlayerActionPoints;
            nkCell.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
        }

        // Update is called once per frame
        private void Update() {
            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "NKCell") {
                healthBar.GetComponent<Slider>().value = nkCell.playerHealth;
                actionBar.GetComponent<Slider>().value = nkCell.playerActionPoints;
                halo.enabled = true;
                nkCell.MovePlayer();
            } else {
                halo.enabled = false;
            }

            if (nkCell.playerActionPoints == 0) {
                TurnManager.turnEnd = true;
                nkCell.PointsRefresh(nkCell.playerActionPoints, nkCell.defaultPlayerActionPoints);
            }

            if (nkCell.playerHealth == 0) {
                deathSoundPlayer.Play();
                // Changes indicator text on HUD
                gameManagement.GetComponent<GameManagement>().StartIndicator("NK cell has been eliminated");
            }

            if (Input.GetMouseButtonDown(0) && nkCell.canMove) {
                movementSoundPlayer.Play();
                gameManagement.GetComponent<GameManagement>().StartIndicator("NK cell has moved");
                nkCell.playerActionPoints -= 1;
            } else if (Input.GetMouseButtonDown(0) && nkCell.canAttack) {
                attackSoundPlayer.Play();
                nkCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                nkCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}