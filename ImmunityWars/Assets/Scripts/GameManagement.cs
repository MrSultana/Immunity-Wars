using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Interaction {
    public class GameManagement : MonoBehaviour {

        static GameObject[] playersArray;
        static GameObject[] enemiesArray;
        static GameObject[] playerEnemyManagement = new GameObject[10];

        public void Start() {
            playersArray = GameObject.FindGameObjectsWithTag("Player");
            /*for (int i = 0; i < playersArray.Length; i++) {
                Debug.Log(playersArray[i]);
            }

            enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemiesArray.Length; i++) {
                Debug.Log(enemiesArray[i]);
            }*/
        }

        public static void GameEnd() {
            if (GameObject.FindGameObjectsWithTag("Player").Length <= 0) {
                Debug.Log("The invaders won!");
                Debug.Log("Closing game...");
                Application.Quit();
            } 
            else if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0) {
                Debug.Log("The immune cells won!");
                Debug.Log("Closing game...");
                Application.Quit();
            }

        }

        public static void SkipTurn() {
            playerEnemyManagement = playersArray.Concat(enemiesArray).ToArray(); // Add both player and enemy arrays together to form one array
            for (int i = 0; i < playerEnemyManagement.Length; i++) {
                /*if (!GameObject.Find(playerEnemyManagement[i].name).activeSelf) { // If the object is inactive
                    TurnManager.playerEnemyToSkip.Add(i);
                }*/
                Debug.Log(playerEnemyManagement[i].name);
            }
        }

        private void Update() {
            GameEnd();
        }
    }
}
