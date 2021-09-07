using UnityEngine;

namespace Interaction {

    public class Enemy : MonoBehaviour {
        private int enemyHealth;
        private int attackDamage;
        private Vector3 newPosition;

        public void Start() {
            newPosition = transform.position;
        }

        public void Update() {
        }

        public Enemy(int enemyHealth, int attackDamage) {
            this.enemyHealth = enemyHealth;
            this.attackDamage = attackDamage;
        }

        private void Attack(int attackDamage) {
        }

        public void MoveEnemy() {
            if (Input.GetMouseButton(0)) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    //Debug.Log(hit.point);
                    newPosition = hit.point;
                    newPosition.y = 1.2f;
                    newPosition = ExtensionMethods.RoundVector3(newPosition, 1.2f);
                    Debug.Log(newPosition);
                    transform.position = newPosition;
                }
            }
        }
    }
}