using System;
using System.Collections;
using UnityEngine;

namespace Interaction {

    public class TurnManager : MonoBehaviour {

        public enum Turns { TCell, NKCell, Neutrophil, BCell, KillerTCell, CAurisFungus, Covid19, EColi, MTuberculosis, SAureus };
        public static string currentTurn;
        public static bool turnEnd = false;
        public static bool newTurn = false;

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
                

                turnEnd = false;
                    
                currentTurn = Enum.GetName(typeof(Turns), i);
                if (i == 10) {
                    Debug.Log("Jeff");
                    StartTrackTurn();
                    break;
                }

                yield return new WaitUntil(() => turnEnd == true);
                Debug.Log(turnEnd);
                if (turnEnd) {
                    newTurn = true;
                    turnEnd = false;
                    yield return new WaitUntil(() => turnEnd == false);
                    yield return new WaitForSeconds(.25f);
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