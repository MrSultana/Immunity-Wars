using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Interaction;

public class HealthActionBar : MonoBehaviour {
    // For Healthbar
    public Slider healthSlider;
    // For Action Points Bar
    public Slider actionSlider;

    public int currentHealth;
    public int currentActionPoints;

    public void Update() {
        //SetHealth(healthSlider);
        //SetActionPoints(actionSlider);
    }

    public void SetHealth(Slider healthBar) {
        healthBar.value = currentHealth;
    }

    public void SetActionPoints(Slider actionBar) {
        actionBar.value = currentActionPoints;
    }
}