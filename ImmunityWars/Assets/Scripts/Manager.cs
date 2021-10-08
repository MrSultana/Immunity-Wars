using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    //void Start() => UIPanel.gameObject.SetActive(true); //make sure our pause menu is disabled when scene starts

    private void Update() {
        //Add code for updating when buttons are pressed
    }

    public void StartGame() {
        SceneManager.LoadScene("Level 1 - Artery");
    }

    public void GoToControls() {
        SceneManager.LoadScene("ControlScreen");
    }

    public void GoToCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void Return() {
        SceneManager.LoadScene("TitleMenu");
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void Restart() {
        //SceneManager.LoadScene;
    }
}