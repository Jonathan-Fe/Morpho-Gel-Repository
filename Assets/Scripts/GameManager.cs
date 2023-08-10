using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // How long it takes for the game to restart after the player dies (in seconds)
    public float restartDelay = 1f;

    private void Update()
    {
        // Debug - Restart
        // If the player pressed R, restart the room
        if (Input.GetKey("r"))
        {
            Restart();
        }
        // Debug - Restart the Game
        // Sends the player to the title screen at any time
        if (Input.GetKey("g"))
        {
            SceneManager.LoadScene("Title_Screen");
        }

        // Debug - Force Quit the Game
        if (Input.GetKey("q"))
        {
            Application.Quit();
        }
    }

    // Restart the level with a small delay
    public void RestartOnDeath()
    {
        Invoke("Restart", restartDelay); // Invoke calls a method with a specified day
    }

    // Restarts the active scene when called
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
