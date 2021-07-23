using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Enemy : MonoBehaviour
    {
        int enemyHealth;
        int attackDamage;

        public Enemy(int enemyHealth, int attackDamage)
        {
            this.enemyHealth = enemyHealth;
            this.attackDamage = attackDamage;
            
        }
        private void Attack(int attackDamage)
        {

        }
    }
}

