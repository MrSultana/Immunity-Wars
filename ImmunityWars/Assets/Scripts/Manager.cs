using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Need this for calling UI scripts

public class Manager : MonoBehaviour
{

    //void Start() => UIPanel.gameObject.SetActive(true); //make sure our pause menu is disabled when scene starts

    void Update()
    {
        //Add code for updating when buttons are pressed
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        //SceneManager.LoadScene;
    }
}