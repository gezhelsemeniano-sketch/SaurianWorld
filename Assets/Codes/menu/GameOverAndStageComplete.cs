using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverAndStageComplete : MonoBehaviour
{

    public void OnRestartFloor1Click()
    {
        SceneManager.LoadScene("floor 1");
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void StageSelection()
    {
        SceneManager.LoadScene("Stage Selection");
    }
    public void NextFloor2Click()
    {
        SceneManager.LoadScene("floor 2");
    }
}
        