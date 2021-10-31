using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {

    // For Action Points Bar
    public Slider actionSlider;

    public void SetActionPoints(int actionValue) {
        actionSlider.value = actionValue;
    }
}