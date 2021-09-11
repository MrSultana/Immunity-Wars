using System;
using System.Collections;
using UnityEngine;

namespace Interaction {

    public class TurnManager : MonoBehaviour {

        public enum Turns { TCell, NKCell, Neutrophil, BCell, KillerTCell, AurisFungus, Covid19, Ecoli, MTuberculosis, SAureus };
        public static string currentTurn;
        public static bool turnEnd = true;
        public static bool newTurn = false;

        /*public string GetCurrentTurn() {
            return
        }*/

        public void Start() {
            StartTurnEnd();


        }

        public IEnumerator TrackTurn() {
            for (int i = 0; i < Enum.GetValues(typeof(Turns)).Length; i++) {
                turnEnd = false;


                currentTurn = Enum.GetName(typeof(Turns), i);
                yield return new WaitUntil(() => turnEnd == true);
                if (turnEnd) {
                    newTurn = true;
                    continue; // exit if and while loop to continue interation in for loop
                }
            }
        }

        /*public string[] getTurns {
            get { return Turns; }
        }*/

        public void StartTurnEnd() {
            StartCoroutine(TrackTurn());
        }

        public static bool HasTurnEnded() {
            
            if(turnEnd) {
                return true;
            }

            else {
                return false;
            }
        }
    }
}