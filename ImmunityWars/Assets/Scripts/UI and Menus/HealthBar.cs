using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interaction {
    public class HealthBar : MonoBehaviour {
        // For Healthbar
        public Slider healthSlider; 

        public void SetHealth(int healthValue) {
            healthSlider.value = healthValue;
        }
    }
}