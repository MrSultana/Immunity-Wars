using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    public class Player : MonoBehaviour {
        int playerHealth;
        int defaultPlayerActionPoints;
        int playerActionPoints;
        bool newTurn = false;
        PathFind.Grid grid;

        public Player(int playerHealth, int defaultPlayerActionPoints) {
            this.playerHealth = playerHealth;
            this.playerActionPoints = defaultPlayerActionPoints;
        }
        private void Damage(int damage) {
            playerHealth = playerHealth - damage;
        }

        private void Action(int pointsUsed) {
            playerActionPoints = playerActionPoints - pointsUsed;
        }

        private void PointsRefresh(int playerActionPoints) {
            if (newTurn) {
                playerActionPoints = defaultPlayerActionPoints;
            }
        }

        public void MovePlayer() {
            //grid = GridMaker.ReturnGrid();

        }
    }
}

