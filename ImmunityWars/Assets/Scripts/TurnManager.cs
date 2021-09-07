using System;
using UnityEngine;

namespace Interaction {

    public class TurnManager : MonoBehaviour {

        public enum Turns { TCell, NKCell, Neutrophil, BCell, KillerTCell, AurisFungus, Covid19, Ecoli, MTuberculosis, SAureus };

        public string[] turnsNames;
        public string currentTurn;
        public bool turnEnd;

        public TurnManager() {
            turnEnd = true;
            turnsNames = Enum.GetNames(typeof(Turns));
            currentTurn = turnsNames[0];
        }

        /*public string GetCurrentTurn() {
            return
        }*/

        public void TurnEnd() {
            for (int i = 0; i < turnsNames.Length; i++) {
                turnEnd = false;
                currentTurn = turnsNames[i];
                while (turnEnd == false) {
                    //Debug.Log(currentTurn);
                    if (turnEnd) {
                        continue; // exit if and while loop to continue interation in for loop
                    }
                }
            }
        }

        /*public string[] getTurns {
            get { return Turns; }
        }*/
    }
}