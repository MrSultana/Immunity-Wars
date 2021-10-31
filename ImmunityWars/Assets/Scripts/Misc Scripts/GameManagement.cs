using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Interaction {

    public class GameManagement : MonoBehaviour {
        public static GameObject[] playersArray;
        public static GameObject[] enemiesArray;
        public static GameObject[] playerEnemyManagement = new GameObject[10];
        public static GameObject skipTurnObject;

        public Text gameEndTitle;
        public GameObject endGameScreen;

        public void Start() {
            playersArray = GameObject.FindGameObjectsWithTag("Player");
            /*for (int i = 0; i < playersArray.Length; i++) {
                Debug.Log(playersArray[i]);
            }*/

            enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
            /*for (int i = 0; i < enemiesArray.Length; i++) {
                Debug.Log(enemiesArray[i]);
            }*/
            playerEnemyManagement = playersArray.Concat(enemiesArray).ToArray();
        }

        public void GameEnd() {
            if (GameObject.FindGameObjectsWithTag("Player").Length <= 0) {
                gameEndTitle.text = "The Invaders Won!";
                endGameScreen.SetActive(true);
                Application.Quit();
            }
            else if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0) {
                gameEndTitle.text = "The Immune Cells Won!";
                endGameScreen.SetActive(true);
                Application.Quit();
            }
        }

        public static void SkipTurn() {
            // Add both player and enemy arrays together to form one array
            for (int i = 0; i < playerEnemyManagement.Length; i++) {
                skipTurnObject = GameObject.Find(playerEnemyManagement[i].name);
                if (!skipTurnObject.activeInHierarchy) { // If the object is inactive
                    Debug.Log(playerEnemyManagement[i].name);
                }
            }
        }

        private void Update() {
            GameEnd();
        }
    }
}