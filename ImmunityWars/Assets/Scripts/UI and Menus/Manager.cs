using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene("Level 1 - Artery");
    }

    public void GoToControls() {
        SceneManager.LoadScene("ControlScreen");
    }

    public void GoToInfo() {
        SceneManager.LoadScene("Info");
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
}