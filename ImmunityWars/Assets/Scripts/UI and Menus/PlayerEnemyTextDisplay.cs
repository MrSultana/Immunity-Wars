using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interaction {
    public class PlayerEnemyTextDisplay : MonoBehaviour {
        public Text textBox;

        public void SetText() {
            textBox.text = TurnManager.currentTurn;
        }

        public void Update() {
            SetText();
        }
    }
}
