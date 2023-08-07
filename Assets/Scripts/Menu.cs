using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ToLevelSelect()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Title_Screen");
    }

    public void ToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ToTestStage()
    {
        SceneManager.LoadScene("Test_Stage");
    }

    public void ToStageOne()
    {
        SceneManager.LoadScene("Stage_01");
    }

    public void ToStageTwo()
    {
        SceneManager.LoadScene("Stage_02");
    }

    public void ToStageThree()
    {
        SceneManager.LoadScene("Stage_03");
    }

    public void ToTransformations()
    {
        SceneManager.LoadScene("Instructions_Transformations");
    }
}
