using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // called when the "Play" button is pressed
    public void OnPlayButton ()
    {
        SceneManager.LoadScene("Level1");
    }

    // called when the "Quit" button is pressed
    public void OnQuitButton ()
    {
        Application.Quit();
    }
}