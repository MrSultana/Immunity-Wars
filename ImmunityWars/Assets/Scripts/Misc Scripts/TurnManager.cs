using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Interaction {

    public class TurnManager : MonoBehaviour {

        public enum Turns { TCell, NKCell, Neutrophil, BCell, KillerTCell, CAurisFungus, Covid19, EColi, MTuberculosis, SAureus };

        public static string currentTurn;
        public static bool turnEnd = false;
        public static bool newTurn = false;

        public static List<int> playerEnemyToSkip = new List<int>();

        /*public string GetCurrentTurn() {
            return
        }*/

        public void Start() {
            StartTrackTurn();
        }

        public void Update() {
        }

        public IEnumerator TrackTurn() {
            for (int i = 0; i < Enum.GetValues(typeof(Turns)).Length + 1; i++) {
                Debug.Log(i);

                
                if (playerEnemyToSkip.Contains(i)) {
                    Debug.Log("Skipping " + Enum.GetName(typeof(Turns), i));
                    continue;
                }

                turnEnd = false;
                
                currentTurn = Enum.GetName(typeof(Turns), i);
                if (i == 10) { // resets the loop if all 10 turns have finished
                    Debug.Log("Jeff");
                    StartTrackTurn();
                    break;
                }

                yield return new WaitUntil(() => turnEnd == true); // pauses for loop execution until turnEnd = true
                Debug.Log(turnEnd);
                if (turnEnd) {
                    newTurn = true;
                    turnEnd = false;
                    yield return new WaitUntil(() => turnEnd == false);
                    yield return new WaitForSeconds(.25f); // waits 1/4 of a second, to stop an error from happening where the last player got an extra turn
                }
            }
        }

        /*public string[] getTurns {
            get { return Turns; }
        }*/

        public void StartTrackTurn() {
            StartCoroutine(TrackTurn());
        }

        
    }
}