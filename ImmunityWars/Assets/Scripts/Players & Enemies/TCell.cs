using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class TCell : MonoBehaviour {
        private PlayerEnemy tCell;

        public GameObject healthBar;
        public GameObject actionBar;

        public Behaviour halo;

        public Text indicatorsText;

        public GameObject gameManagement;

        // For sound effects
        public AudioSource deathSoundPlayer;
        public AudioSource movementSoundPlayer;

        //public int testValue = 3;

        // Start is called before the first frame update
        private void Start() {
            tCell = gameObject.AddComponent<PlayerEnemy>();
            tCell.indicatorsText = indicatorsText;
            tCell.defaultPlayerActionPoints = 3;
            tCell.playerActionPoints = tCell.defaultPlayerActionPoints;
            tCell.playerHealth = 3;

            PlayerEnemy.startingPositions.Add(transform.position);
            foreach (var x in PlayerEnemy.startingPositions) {
                Debug.Log(x.ToString());
            }
        }

        // Update is called once per frame
        private void Update() {
            if (tCell.playerActionPoints == 0) {
                halo.enabled = false;
                if (halo.enabled == false) {
                    Debug.Log("Jeff");
                }
                TurnManager.turnEnd = true;
                tCell.PointsRefresh(tCell.playerActionPoints, tCell.defaultPlayerActionPoints);
            }

            //Debug.Log(TurnManager.currentTurn);
            if (TurnManager.currentTurn == "TCell") {
                healthBar.GetComponent<Slider>().value = tCell.playerHealth;
                actionBar.GetComponent<Slider>().value = tCell.playerActionPoints;
                halo.enabled = true;
                tCell.MovePlayer();
            } else {
                halo.enabled = false;
            }

            if (tCell.playerHealth == 0) {
                deathSoundPlayer.Play();
                gameManagement.GetComponent<GameManagement>().StartIndicator("T cell has been eliminated");
            }
            

            if (Input.GetMouseButtonDown(0) && tCell.canMove) {
                movementSoundPlayer.Play();
                tCell.playerActionPoints -= 1;
            }
            /*if (Input.GetMouseButton(0)) {
                tCell.playerActionPoints -= 1; // Everytime the player makes a movement, decrease the action points
            }*/
        }
    }
}