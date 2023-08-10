using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Sends Player to the Level Select
    public void ToLevelSelect()
    {
        SceneManager.LoadScene("Level_Select");
    }

    // Sends the player back to the Title
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title_Screen");
    }

    // Sends the Player to the Instructions Page
    public void ToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    // Sends the Player to the Test Stage
    public void ToTestStage()
    {
        SceneManager.LoadScene("Test_Stage");
    }

    // Sends Player to Stage 1
    public void ToStageOne()
    {
        SceneManager.LoadScene("Stage_01");
    }

    // Sends Player to Stage 2
    public void ToStageTwo()
    {
        SceneManager.LoadScene("Stage_02");
    }

    // Sends Player to Stage 3
    public void ToStageThree()
    {
        SceneManager.LoadScene("Stage_03");
    }

    // Sends Player to the additional Instructions Page
    public void ToTransformations()
    {
        SceneManager.LoadScene("Instructions_Transformations");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
