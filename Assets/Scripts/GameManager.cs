using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;

    private void Update()
    {
        // Debug - Restart
        if (Input.GetKey("r"))
        {
            Restart();
        }
    }
    public void LevcelComplete()
    {

    }

    // Restart the level with a small delay
    // Perhaps flash some death text or image before restarting
    public void RestartOnDeath()
    {
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
