using UnityEngine;

namespace Interaction {

    public class TurnManager : MonoBehaviour {
        public string[] turns = new string[10] { "TCell", "NKCell", "Neutrophil", "BCell", "KillerTCell", "CAurisFungus", "Covid19", "Ecoli", "MTuberculosis", "SAureus" };
        public string currentTurn;
        public bool turnEnd = true;

        public TurnManager() {
            currentTurn = turns[0];
        }

        public string GetCurrentTurn() {


            return 
        }

        // Start is called before the first frame update
        private void Start() {
            //Debug.Log(turns[0]);
        }

        public void TurnEnd() {
            for (int i = 0; i < turns.Length; i++) {
                turnEnd = false;
                while (turnEnd == false) {
                    currentTurn = turns[i];
                    //Debug.Log(currentTurn);
                    turnEnd = true;
                }
            }
        }

        // Update is called once per frame
        private void Update() {
            
        }

        public string[] getTurns {
            get { return turns; }
        }
    }
}